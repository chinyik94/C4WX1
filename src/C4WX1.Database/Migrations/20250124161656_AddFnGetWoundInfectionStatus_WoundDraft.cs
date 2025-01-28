using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4WX1.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddFnGetWoundInfectionStatus_WoundDraft : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE OR REPLACE FUNCTION fn_GetWoundInfectionStatus_WoundDraft(draft_id INT)
                RETURNS BOOLEAN AS $$
                DECLARE
                    -- Core wound assessment data
                    r_wound RECORD;
                    r_vitals RECORD;
                    r_previous RECORD;
                    
                    -- Infection criteria counters
                    infection_criteria_count INT := 0;
                    
                    -- Exudate level mapping
                    exudate_levels CONSTANT jsonb := '{
                        "Absent": 0,
                        "Mild +": 1,
                        "Moderate ++": 2,
                        "Excessive +++": 3
                    }';
                BEGIN
                    -- Get current wound assessment
                    SELECT 
                        pwd."VisitDate",
                        pwd."Suffering",
                        pwd."Exudate",
                        pwd."IsSwelling",
                        pwd."IsRedness",
                        pwd."IsSmell",
                        pwd."IsWarmToTouch",
                        pwd."PatientWoundID_FK" AS wound_id,
                        pwd."PatientID_FK" AS patient_id,
                        pwd."SurfaceArea",
                        pwd."AverageDepth"
                    INTO r_wound
                    FROM "PatientWoundDraft" pwd
                    WHERE pwd."PatientWoundDraftID" = draft_id 
                    AND pwd."IsDeleted" = FALSE;
                
                    -- First visit check - return true if excessive exudate
                    IF r_wound.wound_id IS NULL AND 
                       r_wound.Exudate IN ('Moderate ++', 'Excessive +++') THEN
                        RETURN TRUE;
                    END IF;
                
                    -- Get vital signs for the visit date
                    WITH vital_signs AS (
                        SELECT 
                            vsd.vitalSignTypeId,
                            vsd.detailvalue::numeric
                        FROM "VitalSigns" vs
                        JOIN "VitalSignDetails" vsd ON vs.id = vsd.vitalSignId
                        WHERE vs.patientId = r_wound.patient_id
                        AND DATE(vs.updatedDate) = DATE(r_wound.VisitDate)
                        AND vsd.vitalSignTypeId IN (1,2,3,6)  -- Temperature, BP sys/dias, Pulse
                    )
                    SELECT 
                        MAX(CASE WHEN vitalSignTypeId = 1 THEN detailvalue END) AS temperature,
                        MAX(CASE WHEN vitalSignTypeId = 2 THEN detailvalue END) AS bp_sys,
                        MAX(CASE WHEN vitalSignTypeId = 3 THEN detailvalue END) AS bp_dias,
                        MAX(CASE WHEN vitalSignTypeId = 6 THEN detailvalue END) AS pulse
                    INTO r_vitals
                    FROM vital_signs;
                
                    -- Check vital signs for infection indicators
                    IF r_vitals.temperature > 38 AND (
                       r_vitals.bp_sys NOT BETWEEN 100 AND 140 OR
                       r_vitals.bp_dias NOT BETWEEN 60 AND 90 OR
                       r_vitals.pulse NOT BETWEEN 50 AND 100
                    ) THEN
                        RETURN TRUE;
                    END IF;
                
                    -- Get previous assessment
                    WITH prev_visit AS (
                        SELECT 
                            "Suffering",
                            "Exudate",
                            "SurfaceArea",
                            "AverageDepth",
                            "VisitDate"
                        FROM "PatientWoundVisit"
                        WHERE "PatientWoundID_FK" = r_wound.wound_id
                        AND "IsDeleted" = FALSE
                        AND "VisitDate" < r_wound.VisitDate
                        ORDER BY "VisitDate" DESC
                        LIMIT 1
                    ),
                    prev_healing AS (
                        SELECT EXISTS (
                            SELECT 1
                            FROM "PatientWoundVisit"
                            WHERE "PatientWoundID_FK" = r_wound.wound_id
                            AND (r_wound.VisitDate - "VisitDate") >= INTERVAL '14 days'
                            AND ("SurfaceArea" < r_wound.SurfaceArea OR 
                                 "AverageDepth" < r_wound.AverageDepth)
                        ) AS slow_healing
                    )
                    SELECT 
                        pv.*,
                        ph.slow_healing
                    INTO r_previous
                    FROM prev_visit pv
                    CROSS JOIN prev_healing ph;
                
                    -- Count infection criteria
                    -- 1. Slow healing
                    IF r_previous.slow_healing THEN
                        infection_criteria_count := infection_criteria_count + 1;
                    END IF;
                
                    -- 2. Increased pain
                    IF r_previous.Suffering IS NOT NULL AND 
                       (r_wound.Suffering > r_previous.Suffering OR r_wound.Suffering > 3) THEN
                        infection_criteria_count := infection_criteria_count + 1;
                    END IF;
                
                    -- 3. Increased exudate
                    IF r_previous.Exudate IS NOT NULL AND 
                       (exudate_levels->r_wound.Exudate)::int > (exudate_levels->r_previous.Exudate)::int THEN
                        infection_criteria_count := infection_criteria_count + 1;
                    END IF;
                
                    -- 4-7. Direct symptoms
                    infection_criteria_count := infection_criteria_count + 
                        (CASE WHEN r_wound.IsSwelling THEN 1 ELSE 0 END) +
                        (CASE WHEN r_wound.IsRedness THEN 1 ELSE 0 END) +
                        (CASE WHEN r_wound.IsSmell THEN 1 ELSE 0 END) +
                        (CASE WHEN r_wound.IsWarmToTouch THEN 1 ELSE 0 END);
                
                    -- Return true if 3 or more criteria are met
                    RETURN infection_criteria_count >= 3;
                END;
                $$ LANGUAGE plpgsql;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                DROP FUNCTION IF EXISTS "fn_GetWoundInfectionStatus_WoundDraft";
                """);
        }
    }
}
