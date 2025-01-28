using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4WX1.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddSpRptProductivity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE OR REPLACE FUNCTION "fn_SpRptProductivity"(
                    report_type_param integer,
                    user_id_param integer,
                    user_category_id_param integer,
                    start_date_param timestamp,
                    end_date_param timestamp
                )
                RETURNS TABLE (
                    "Label" text,
                    "visitDate" text,
                    "visitCount" BIGINT
                ) AS $$
                DECLARE
                    months_diff integer;
                    ica_task_type_id integer;
                    care_report_task_type_id integer;
                    avg_amount decimal(18,2);
                    avg_time integer;
                BEGIN
                    -- Calculate months difference
                    months_diff := EXTRACT(MONTH FROM age(end_date_param, start_date_param));
                
                    IF report_type_param = 1 THEN
                        -- No. of Visits per month
                        RETURN QUERY
                        WITH months AS (
                            SELECT start_date_param + (n || ' months')::interval AS target_date
                            FROM generate_series(0, months_diff - 1) n
                        ),
                        ica_counts AS (
                            SELECT 
                                EXTRACT(YEAR FROM "CreatedDate") AS visit_year,
                                EXTRACT(MONTH FROM "CreatedDate") AS visit_month,
                                COUNT(*) AS ica_count
                            FROM "InitialCareAssessment" i
                            WHERE NOT i."IsDeleted"
                                AND (user_id_param IS NULL OR i."CreatedBy_FK" = user_id_param)
                                AND i."CreatedDate" >= start_date_param 
                                AND i."CreatedDate" < end_date_param
                                AND (user_category_id_param IS NULL OR EXISTS(
                                    SELECT 1 FROM "UserUserType" ut
                                    JOIN "UserType" t ON ut."UserTypeID_FK" = t."UserTypeID"
                                    WHERE ut."UserID_FK" = i."CreatedBy_FK" 
                                    AND t."UserCategoryID_FK" = user_category_id_param
                                ))
                            GROUP BY EXTRACT(YEAR FROM "CreatedDate"), EXTRACT(MONTH FROM "CreatedDate")
                        ),
                        cr_counts AS (
                            SELECT 
                                EXTRACT(YEAR FROM "VisitStartDate") AS visit_year,
                                EXTRACT(MONTH FROM "VisitStartDate") AS visit_month,
                                COUNT(*) AS cr_count
                            FROM "CareReport" c
                            WHERE NOT c."IsDeleted"
                                AND (user_id_param IS NULL OR c."CreatedBy_FK" = user_id_param)
                                AND c."VisitStartDate" >= start_date_param 
                                AND c."VisitStartDate" < end_date_param
                                AND (user_category_id_param IS NULL OR EXISTS(
                                    SELECT 1 FROM "UserUserType" ut
                                    JOIN "UserType" t ON ut."UserTypeID_FK" = t."UserTypeID"
                                    WHERE ut."UserID_FK" = c."CreatedBy_FK" 
                                    AND t."UserCategoryID_FK" = user_category_id_param
                                ))
                            GROUP BY EXTRACT(YEAR FROM "VisitStartDate"), EXTRACT(MONTH FROM "VisitStartDate")
                        )
                        SELECT 
                            ''::text AS "Label",
                            UPPER(to_char(m.target_date, 'Mon-YY')) AS "visitDate",
                            COALESCE(i.ica_count, 0) + COALESCE(c.cr_count, 0) AS "visitCount"
                        FROM months m
                        LEFT JOIN ica_counts i ON 
                            EXTRACT(YEAR FROM m.target_date) = i.visit_year 
                            AND EXTRACT(MONTH FROM m.target_date) = i.visit_month
                        LEFT JOIN cr_counts c ON 
                            EXTRACT(YEAR FROM m.target_date) = c.visit_year 
                            AND EXTRACT(MONTH FROM m.target_date) = c.visit_month
                        ORDER BY m.target_date;
                	ELSIF report_type_param = 2 THEN
                        -- No of visits per staff
                        RETURN QUERY
                        WITH months AS (
                            SELECT start_date_param + (n || ' months')::interval AS target_date
                            FROM generate_series(0, months_diff - 1) n
                        ),
                        ica_counts AS (
                            SELECT 
                                i."CreatedBy_FK",
                                EXTRACT(YEAR FROM "CreatedDate") AS visit_year,
                                EXTRACT(MONTH FROM "CreatedDate") AS visit_month,
                                COUNT(*) AS ica_count
                            FROM "InitialCareAssessment" i
                            WHERE NOT i."IsDeleted"
                                AND (user_id_param IS NULL OR i."CreatedBy_FK" = user_id_param)
                                AND i."CreatedDate" >= start_date_param 
                                AND i."CreatedDate" < end_date_param
                            GROUP BY i."CreatedBy_FK", EXTRACT(YEAR FROM "CreatedDate"), EXTRACT(MONTH FROM "CreatedDate")
                        ),
                        cr_counts AS (
                            SELECT 
                                c."CreatedBy_FK",
                                EXTRACT(YEAR FROM "VisitStartDate") AS visit_year,
                                EXTRACT(MONTH FROM "VisitStartDate") AS visit_month,
                                COUNT(*) AS cr_count
                            FROM "CareReport" c
                            WHERE NOT c."IsDeleted"
                                AND (user_id_param IS NULL OR c."CreatedBy_FK" = user_id_param)
                                AND c."VisitStartDate" >= start_date_param 
                                AND c."VisitStartDate" < end_date_param
                            GROUP BY c."CreatedBy_FK", EXTRACT(YEAR FROM "VisitStartDate"), EXTRACT(MONTH FROM "VisitStartDate")
                        )
                        SELECT 
                            u."Firstname" || ' ' || u."Lastname" AS "Label",
                            UPPER(to_char(m.target_date, 'Mon-YY')) AS "visitDate",
                            COALESCE(i.ica_count, 0) + COALESCE(c.cr_count, 0) AS "visitCount"
                        FROM "Users" u
                        CROSS JOIN months m
                        LEFT JOIN ica_counts i ON 
                            u."UserId" = i."CreatedBy_FK"
                            AND EXTRACT(YEAR FROM m.target_date) = i.visit_year 
                            AND EXTRACT(MONTH FROM m.target_date) = i.visit_month
                        LEFT JOIN cr_counts c ON 
                            u."UserId" = c."CreatedBy_FK"
                            AND EXTRACT(YEAR FROM m.target_date) = c.visit_year 
                            AND EXTRACT(MONTH FROM m.target_date) = c.visit_month
                        WHERE NOT u."IsDeleted"
                            AND (user_id_param IS NULL OR u."UserId" = user_id_param)
                            AND (user_category_id_param IS NULL OR EXISTS(
                                SELECT 1 FROM "UserUserType" ut
                                JOIN "UserType" t ON ut."UserTypeID_FK" = t."UserTypeID"
                                WHERE ut."UserID_FK" = u."UserId" 
                                AND t."UserCategoryID_FK" = user_category_id_param
                            ))
                        ORDER BY u."Firstname" || ' ' || u."Lastname", m.target_date;
                	ELSIF report_type_param = 3 THEN
                        -- No. of Different Type Visits
                        RETURN QUERY
                        WITH months AS (
                            SELECT start_date_param + (n || ' months')::interval AS target_date
                            FROM generate_series(0, months_diff - 1) n
                        ),
                        visit_types AS (
                            SELECT 1 AS visit_type UNION ALL SELECT 2
                        ),
                        visit_counts AS (
                            SELECT 
                                1 AS visit_type,
                                EXTRACT(YEAR FROM "CreatedDate") AS visit_year,
                                EXTRACT(MONTH FROM "CreatedDate") AS visit_month,
                                COUNT(*) AS visit_count
                            FROM "InitialCareAssessment" i
                            WHERE NOT i."IsDeleted"
                                AND (user_id_param IS NULL OR i."CreatedBy_FK" = user_id_param)
                                AND i."CreatedDate" >= start_date_param 
                                AND i."CreatedDate" < end_date_param
                                AND (user_category_id_param IS NULL OR EXISTS(
                                    SELECT 1 FROM "UserUserType" ut
                                    JOIN "UserType" t ON ut."UserTypeID_FK" = t."UserTypeID"
                                    WHERE ut."UserID_FK" = i."CreatedBy_FK" 
                                    AND t."UserCategoryID_FK" = user_category_id_param
                                ))
                            GROUP BY EXTRACT(YEAR FROM "CreatedDate"), EXTRACT(MONTH FROM "CreatedDate")
                            UNION ALL
                            SELECT 
                                2 AS visit_type,
                                EXTRACT(YEAR FROM "VisitStartDate") AS visit_year,
                                EXTRACT(MONTH FROM "VisitStartDate") AS visit_month,
                                COUNT(*) AS visit_count
                            FROM "CareReport" c
                            WHERE NOT c."IsDeleted"
                                AND (user_id_param IS NULL OR c."CreatedBy_FK" = user_id_param)
                                AND c."VisitStartDate" >= start_date_param 
                                AND c."VisitStartDate" < end_date_param
                                AND (user_category_id_param IS NULL OR EXISTS(
                                    SELECT 1 FROM "UserUserType" ut
                                    JOIN "UserType" t ON ut."UserTypeID_FK" = t."UserTypeID"
                                    WHERE ut."UserID_FK" = c."CreatedBy_FK" 
                                    AND t."UserCategoryID_FK" = user_category_id_param
                                ))
                            GROUP BY EXTRACT(YEAR FROM "VisitStartDate"), EXTRACT(MONTH FROM "VisitStartDate")
                        )
                        SELECT 
                            CASE vt.visit_type 
                                WHEN 1 THEN 'Initial Care Assessment'
                                ELSE 'Care Report'
                            END AS "Label",
                            UPPER(to_char(m.target_date, 'Mon-YY')) AS "visitDate",
                            COALESCE(v.visit_count, 0) AS "visitCount"
                        FROM months m
                        CROSS JOIN visit_types vt
                        LEFT JOIN visit_counts v ON 
                            vt.visit_type = v.visit_type 
                            AND EXTRACT(YEAR FROM m.target_date) = v.visit_year 
                            AND EXTRACT(MONTH FROM m.target_date) = v.visit_month
                        ORDER BY vt.visit_type, m.target_date;
                	ELSIF report_type_param = 5 THEN
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
                	
                	    RETURN QUERY
                	    WITH "service_types" AS (
                	        SELECT "CodeId", "CodeName"
                	        FROM "Code"
                	        WHERE NOT "IsDeleted"
                	        AND "CodeTypeId_FK" = (
                	            SELECT "CodeTypeId"
                	            FROM "CodeType"
                	            WHERE "CodeTypeName" = 'ServiceRequired'
                	        )
                	    ),
                	    "visit_counts" AS (
                	        SELECT 
                	            ts."CodeID_FK",
                	            COUNT(DISTINCT t."TaskID") AS "visitCount"
                	        FROM "TaskUserLog" tul
                	        JOIN "Task" t ON 
                	            tul."TaskID_FK" = t."TaskID" 
                	            AND NOT t."IsDeleted"
                	            AND (t."Pending" IS NULL OR NOT t."Pending")
                	            AND t."ActionTypeID_FK" IN (ica_task_type_id, care_report_task_type_id)
                	        JOIN "TaskServicesRequired" ts ON t."TaskID" = ts."TaskID_FK"
                	        WHERE 
                	            NOT tul."IsDeleted"
                	            AND (user_id_param IS NULL OR tul."UserID_FK" = user_id_param)
                	            AND tul."StartDate" >= start_date_param 
                	            AND tul."EndDate" < end_date_param
                	        GROUP BY ts."CodeID_FK"
                	    )
                	    SELECT 
                	        sv."CodeName"::text AS "Label",
                	        UPPER(TO_CHAR(start_date_param, 'Mon-YY')) AS "visitDate",
                	        COALESCE(vc."visitCount", 0) AS "visitCount"
                	    FROM "service_types" sv
                	    LEFT JOIN "visit_counts" vc ON vc."CodeID_FK" = sv."CodeId"
                	    WHERE vc."visitCount" > 0
                	    ORDER BY sv."CodeName";
                	END IF;
                END;
                $$ LANGUAGE plpgsql;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                DROP FUNCTION IF EXISTS "fn_SpRptProductivity";
                """);
        }
    }
}
