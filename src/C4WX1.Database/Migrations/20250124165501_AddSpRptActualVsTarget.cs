using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4WX1.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddSpRptActualVsTarget : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE OR REPLACE FUNCTION "fn_SpRptActualVsTarget"(
                    target_param INTEGER,
                    start_date_param DATE,
                    end_date_param DATE,
                    status_param VARCHAR(15),    -- 'ALL', 'Active', 'Suspend', 'Discharge', 'Discharge RIP'
                    patient_type_param VARCHAR(30),    -- 'Long Term', 'Episodic'
                    filter_param VARCHAR(400)    -- values separated by '|'. 'Active' -> 'New' and/or 'Current'
                ) RETURNS TABLE (
                    "Label" TEXT,
                    "Seq" INTEGER,
                    "SetSeq" INTEGER,
                    "SetName" VARCHAR(20),
                    "Value" INTEGER
                ) AS $$
                DECLARE
                    months_count INTEGER;
                    first_month_date DATE;
                    slh_id_var INTEGER;
                BEGIN
                    -- Calculate months and first month date
                    months_count := DATE_PART('month', AGE(end_date_param, start_date_param)) + 1;
                    first_month_date := DATE_TRUNC('month', start_date_param);
                    
                    -- Get St Luke's Hospital ID
                    SELECT "CodeId" INTO slh_id_var 
                    FROM "Code" 
                    WHERE "CodeTypeId_FK" = (
                        SELECT "CodeTypeId" 
                        FROM "CodeType" 
                        WHERE "CodeTypeName" = 'PatientReferral'
                    )
                    AND "CodeName" = 'St Luke''s Hospital' 
                    AND "IsDeleted" = FALSE;
                
                    -- Default status to 'All' if null
                    IF status_param IS NULL OR status_param = '' THEN
                        status_param := 'All';
                    END IF;
                
                    RETURN QUERY
                    WITH RECURSIVE months AS (
                        SELECT generate_series(1, months_count) AS rn
                    ),
                    sets AS (
                        SELECT 20 AS "SetSeq", 'Active'::VARCHAR(20) AS "SetName"
                        WHERE status_param IN ('All')
                        UNION ALL
                        SELECT 21, 'New'
                        WHERE status_param = 'Active' 
                        AND patient_type_param = ''
                        AND filter_param LIKE '%New%'
                        UNION ALL
                        SELECT 22, 'Current'
                        WHERE status_param = 'Active'
                        AND patient_type_param = ''
                        AND filter_param LIKE '%Current%'
                        UNION ALL
                        SELECT 23, "PackageName"
                        FROM "Package"
                        WHERE "IsDeleted" = FALSE
                        AND status_param = 'Active'
                        AND patient_type_param = 'Long Term'
                        UNION ALL
                        SELECT 24, 'St Luke''s'
                        WHERE status_param = 'Active'
                        AND patient_type_param = 'Episodic'
                        AND filter_param LIKE '%St Luke''s Hospital%'
                        UNION ALL
                        SELECT 25, 'Others'
                        WHERE status_param = 'Active'
                        AND patient_type_param = 'Episodic'
                        AND filter_param LIKE '%Others%'
                        UNION ALL
                        SELECT 30, 'Suspend'
                        WHERE status_param IN ('All', 'Suspend')
                        UNION ALL
                        SELECT 40, 'Discharge'
                        WHERE status_param IN ('All', 'Discharge')
                        UNION ALL
                        SELECT 50, 'Discharge RIP'
                        WHERE status_param IN ('All', 'Discharge RIP')
                    ),
                    temp_base AS (
                        SELECT 
                            m.rn AS "Seq",
                            first_month_date + ((m.rn - 1) || ' months')::INTERVAL AS "Pd",
                            s."SetSeq",
                            s."SetName"
                        FROM months m
                        CROSS JOIN sets s
                    ),
                    packages AS (
                        SELECT 
                            first_month_date + ((m.rn - 1) || ' months')::INTERVAL AS "Pd",
                            a."PatientID",
                            a."PackageID_FK",
                            p."PackageName"
                        FROM months m
                        CROSS JOIN LATERAL (
                            SELECT "PatientID_FK" AS "PatientID", "ActionTime" AS "Dt", "PackageID_FK"
                            FROM "Audit_PatientPackage"
                            WHERE "AuditAction" <> 'D'
                        ) a
                        JOIN "Package" p ON a."PackageID_FK" = p."PackageID"
                        WHERE a."Dt" < first_month_date + (m.rn || ' months')::INTERVAL
                        AND status_param = 'Active'
                        AND patient_type_param = 'Long Term'
                    ),
                    audit_data AS (
                        SELECT 
                            t."Seq",
                            t."SetSeq",
                            t."SetName",
                            ap."PatientID",
                            t."Pd",
                            max(ap."ActionTime") AS max_dt
                        FROM temp_base t
                        LEFT JOIN LATERAL (
                            SELECT "PatientID", "ActionTime"
                            FROM "Audit_Patient"
                            WHERE "AuditAction" <> 'D'
                        ) ap ON ap."ActionTime" < t."Pd" + INTERVAL '1 month'
                        GROUP BY t."Seq", t."SetSeq", t."SetName", ap."PatientID", t."Pd"
                    )
                    -- Target values
                    SELECT 
                        TO_CHAR(x."Pd" + INTERVAL '1 month - 1 day', 'DD-Mon-YYYY') AS "Label",
                        x."Seq",
                        1 AS "SetSeq",
                        'Target' AS "SetName",
                        target_param AS "Value"
                    FROM temp_base x
                    UNION ALL
                    -- Actual values
                    SELECT 
                        TO_CHAR(tb."Pd" + INTERVAL '1 month - 1 day', 'DD-Mon-YYYY'),
                        tb."Seq",
                        tb."SetSeq",
                        tb."SetName",
                        COUNT(ad."PatientID")::INTEGER AS "Value"
                    FROM temp_base tb
                    LEFT JOIN audit_data ad ON tb."Pd" = ad."Pd" 
                        AND tb."Seq" = ad."Seq" 
                        AND tb."SetName" = (
                            CASE 
                                WHEN status_param IN ('All', 'Suspend', 'Discharge', 'Discharge RIP') THEN 
                                    (SELECT "Status" FROM "Audit_Patient" WHERE "PatientID" = ad."PatientID" AND "ActionTime" = ad.max_dt)
                                WHEN status_param = 'Active' THEN
                                    CASE 
                                        WHEN patient_type_param = '' THEN
                                            CASE 
                                                WHEN DATE_TRUNC('month', (SELECT "AdmittedDate" FROM "Audit_Patient" WHERE "PatientID" = ad."PatientID" AND "ActionTime" = ad.max_dt)) = DATE_TRUNC('month', ad."Pd") THEN 'New'
                                                ELSE 'Current'
                                            END
                                        WHEN patient_type_param = 'Long Term' THEN 
                                            COALESCE((SELECT "PackageName" FROM packages WHERE "PatientID" = ad."PatientID" AND "Pd" = ad."Pd"), '')
                                        WHEN patient_type_param = 'Episodic' THEN
                                            CASE 
                                                WHEN COALESCE((SELECT "PatientReferralByID_FK" FROM "Audit_Patient" WHERE "PatientID" = ad."PatientID" AND "ActionTime" = ad.max_dt), '0') = slh_id_var THEN 'St Luke''s'
                                                ELSE 'Others'
                                            END
                                    END
                            END
                        )
                    WHERE EXISTS (
                        SELECT 1 FROM "Audit_Patient" ap
                        WHERE ap."PatientID" = ad."PatientID"
                        AND ap."ActionTime" = ad.max_dt
                        AND ap."AuditAction" <> 'D'
                        AND ap."Status" IN ('Active', 'Suspend', 'Discharge', 'Discharge RIP')
                        AND (
                            status_param = 'All'
                            OR (status_param IN ('Active', 'Suspend', 'Discharge', 'Discharge RIP') AND ap."Status" = status_param)
                            OR (status_param = 'Active' AND (
                                (patient_type_param = '' AND (
                                    (filter_param LIKE '%New%' AND DATE_TRUNC('month', ap."AdmittedDate") = DATE_TRUNC('month', ad."Pd"))
                                    OR (filter_param LIKE '%Current%' AND DATE_TRUNC('month', ap."AdmittedDate") <> DATE_TRUNC('month', ad."Pd"))
                                ))
                                OR (patient_type_param <> '' AND ap."PatientTypeID_FK" IN (
                                    SELECT "CodeId" FROM "Code"
                                    WHERE "CodeTypeId_FK" = (SELECT "CodeTypeId" FROM "CodeType" WHERE "CodeTypeName" = 'Patient Type')
                                    AND (
                                        (patient_type_param = 'Long Term' AND "CodeName" LIKE '%Long Term%')
                                        OR (patient_type_param = 'Episodic' AND "CodeName" LIKE '%Episodic%'
                                            AND ((filter_param LIKE '%St Luke''s Hospital%' AND COALESCE(ap."PatientReferralByID_FK", '0') = slh_id_var)
                                                OR (filter_param LIKE '%Others%' AND COALESCE(ap."PatientReferralByID_FK", '0') <> slh_id_var))
                                        )
                                    )
                                ))
                            ))
                        )
                    )
                    GROUP BY tb."Pd", tb."Seq", tb."SetSeq", tb."SetName"
                    ORDER BY "Seq", "SetSeq";
                END;
                $$ LANGUAGE plpgsql;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                DROP FUNCTION IF EXISTS "fn_SpRptActualVsTarget";
                """);
        }
    }
}
