using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4WX1.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddSpRptVisitDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE OR REPLACE FUNCTION "fn_SpRptVisitDetail"(
                    user_id_param INTEGER,
                    user_category_id_param INTEGER,
                    start_date_param TIMESTAMP WITHOUT TIME ZONE,
                    end_date_param TIMESTAMP WITHOUT TIME ZONE
                )
                RETURNS TABLE (
                    "Name" TEXT,
                    "VisitDate" TIMESTAMP WITHOUT TIME ZONE,
                    "VisitType" TEXT,
                    "IsBill" CHAR(1),
                    "BillingAmount" NUMERIC
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
                    WITH "VisitData" AS (
                        -- Initial Care Assessment visits
                        SELECT 
                            i."CreatedBy_FK",
                            'Initial Care Assessment'::TEXT AS "VisitType",
                            i."CreatedDate" AS "VisitDate",
                            b."TotalCost"
                        FROM "InitialCareAssessment" i
                        LEFT JOIN "BillingInvoice" b ON i."InitialCareAssessmentID" = b."InitialCareAssessmentID_FK" 
                            AND NOT b."IsDeleted"
                        WHERE NOT i."IsDeleted"
                            AND (user_id_param IS NULL OR i."CreatedBy_FK" = user_id_param)
                            AND i."CreatedDate" >= start_date_param 
                            AND i."CreatedDate" < end_date_param + INTERVAL '1 day'
                        
                        UNION ALL
                        
                        -- Care Report visits
                        SELECT 
                            c."CreatedBy_FK",
                            'Care Report'::TEXT AS "VisitType",
                            c."VisitStartDate" AS "VisitDate",
                            b."TotalCost"
                        FROM "CareReport" c
                        LEFT JOIN "BillingInvoice" b ON c."CareReportID" = b."CareReportID_FK" 
                            AND NOT b."IsDeleted"
                        WHERE NOT c."IsDeleted"
                            AND (user_id_param IS NULL OR c."CreatedBy_FK" = user_id_param)
                            AND c."VisitStartDate" >= start_date_param 
                            AND c."VisitStartDate" < end_date_param + INTERVAL '1 day'
                    )
                    SELECT 
                        u."Firstname" || ' ' || u."Lastname" AS "Name",
                        v."VisitDate",
                        v."VisitType",
                        CASE WHEN v."TotalCost" IS NULL THEN 'N' ELSE 'Y' END AS "IsBill",
                        COALESCE(v."TotalCost", 0) AS "BillingAmount"
                    FROM "Users" u
                    JOIN "VisitData" v ON u."UserId" = v."CreatedBy_FK"
                    WHERE NOT u."IsDeleted"
                        AND (user_id_param IS NULL OR u."UserId" = user_id_param)
                        AND (user_category_id_param IS NULL OR EXISTS(
                            SELECT 1 
                            FROM "UserUserType" ut
                            JOIN "UserType" t ON ut."UserTypeID_FK" = t."UserTypeID"
                            WHERE ut."UserID_FK" = u."UserId" 
                                AND t."UserCategoryID_FK" = user_category_id_param
                        ))
                    ORDER BY u."Firstname" || ' ' || u."Lastname", v."VisitDate";
                END;
                $$ LANGUAGE plpgsql;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                DROP FUNCTION IF EXISTS "fn_SpRptVisitDetail";
                """);
        }
    }
}
