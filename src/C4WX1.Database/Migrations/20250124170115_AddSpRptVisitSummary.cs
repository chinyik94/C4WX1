using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4WX1.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddSpRptVisitSummary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE OR REPLACE FUNCTION "fn_SpRptVisitSummary"(
                    user_id_param INTEGER,
                    user_category_id_param INTEGER,
                    start_date_param TIMESTAMP WITHOUT TIME ZONE,
                    end_date_param TIMESTAMP WITHOUT TIME ZONE
                )
                RETURNS TABLE (
                    "Name" TEXT,
                    "ScheduledCount" BIGINT,
                    "ActualCount" BIGINT,
                    "BillingAmount" NUMERIC,
                    "Average" NUMERIC
                ) AS $$
                DECLARE
                    ica_task_type_id INTEGER;
                    care_report_task_type_id INTEGER;
                BEGIN
                    -- Get task type IDs
                    SELECT "CodeId" INTO ica_task_type_id
                    FROM "Code"
                    WHERE "CodeTypeId_FK" = 1 
                        AND NOT "IsDeleted" 
                        AND "CodeName" = 'Initial Care Assessment'
                    LIMIT 1;
                
                    SELECT "CodeId" INTO care_report_task_type_id
                    FROM "Code"
                    WHERE "CodeTypeId_FK" = 1 
                        AND NOT "IsDeleted" 
                        AND "CodeName" = 'Care Review'
                    LIMIT 1;
                
                    -- Validate task type IDs
                    IF (ica_task_type_id IS NULL OR care_report_task_type_id IS NULL) THEN
                        RAISE EXCEPTION 'Task action type for ICA or Care report cannot be found from Code table.';
                    END IF;
                
                    RETURN QUERY
                    WITH "ScheduledVisits" AS (
                        SELECT 
                            tul."UserID_FK",
                            COUNT(*) AS "ScheduledCount"
                        FROM "TaskUserLog" tul
                        JOIN "Task" t ON tul."TaskID_FK" = t."TaskID" 
                            AND NOT t."IsDeleted" 
                            AND (t."Pending" IS NULL OR NOT t."Pending")
                            AND t."ActionTypeID_FK" IN (ica_task_type_id, care_report_task_type_id)
                        WHERE NOT tul."IsDeleted"
                            AND (user_id_param IS NULL OR tul."UserID_FK" = user_id_param)
                            AND tul."StartDate" >= start_date_param 
                            AND tul."EndDate" < end_date_param + INTERVAL '1 day'
                        GROUP BY tul."UserID_FK"
                    ),
                    "ICAVisits" AS (
                        SELECT 
                            i."CreatedBy_FK",
                            COUNT(*) AS "icaCount",
                            SUM(b."TotalCost") AS "icaAmount"
                        FROM "InitialCareAssessment" i
                        LEFT JOIN "BillingInvoice" b ON i."InitialCareAssessmentID" = b."InitialCareAssessmentID_FK" 
                            AND NOT b."IsDeleted"
                        WHERE NOT i."IsDeleted"
                            AND (user_id_param IS NULL OR i."CreatedBy_FK" = user_id_param)
                            AND i."CreatedDate" >= start_date_param 
                            AND i."CreatedDate" < end_date_param + INTERVAL '1 day'
                        GROUP BY i."CreatedBy_FK"
                    ),
                    "CareReports" AS (
                        SELECT 
                            c."CreatedBy_FK",
                            COUNT(*) AS "crCount",
                            SUM(b."TotalCost") AS "crAmount"
                        FROM "CareReport" c
                        LEFT JOIN "BillingInvoice" b ON c."CareReportID" = b."CareReportID_FK" 
                            AND NOT b."IsDeleted"
                        WHERE NOT c."IsDeleted"
                            AND (user_id_param IS NULL OR c."CreatedBy_FK" = user_id_param)
                            AND c."VisitStartDate" >= start_date_param 
                            AND c."VisitStartDate" < end_date_param + INTERVAL '1 day'
                        GROUP BY c."CreatedBy_FK"
                    )
                    SELECT 
                        u."Firstname" || ' ' || u."Lastname" AS "Name",
                        COALESCE(sv."ScheduledCount", 0) AS "ScheduledCount",
                        COALESCE(ica."icaCount", 0) + COALESCE(cr."crCount", 0) AS "ActualCount",
                        COALESCE(ica."icaAmount", 0) + COALESCE(cr."crAmount", 0) AS "BillingAmount",
                        CASE 
                            WHEN COALESCE(ica."icaCount", 0) + COALESCE(cr."crCount", 0) = 0 THEN 0 
                            ELSE (COALESCE(ica."icaAmount", 0) + COALESCE(cr."crAmount", 0))::NUMERIC / 
                                 (COALESCE(ica."icaCount", 0) + COALESCE(cr."crCount", 0))
                        END AS "Average"
                    FROM "Users" u
                    LEFT JOIN "ScheduledVisits" sv ON u."UserId" = sv."UserID_FK"
                    LEFT JOIN "ICAVisits" ica ON u."UserId" = ica."CreatedBy_FK"
                    LEFT JOIN "CareReports" cr ON u."UserId" = cr."CreatedBy_FK"
                    WHERE NOT u."IsDeleted"
                        AND (user_id_param IS NULL OR u."UserId" = user_id_param)
                        AND (user_category_id_param IS NULL OR EXISTS(
                            SELECT 1 
                            FROM "UserUserType" ut
                            JOIN "UserType" t ON ut."UserTypeID_FK" = t."UserTypeID"
                            WHERE ut."UserID_FK" = u."UserId" 
                                AND t."UserCategoryID_FK" = user_category_id_param
                        ))
                        AND (COALESCE(sv."ScheduledCount", 0) > 0 OR 
                             (COALESCE(ica."icaCount", 0) + COALESCE(cr."crCount", 0)) > 0)
                    ORDER BY u."Firstname" || ' ' || u."Lastname";
                END;
                $$ LANGUAGE plpgsql;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                DROP FUNCTION IF EXISTS "fn_SpRptVisitSummary";
                """);
        }
    }
}
