using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4WX1.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddSpGetWoundInfectionStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE OR REPLACE FUNCTION "fn_SpGetWoundInfectionStatus"(
                    user_id_param INTEGER,
                    patient_id_param INTEGER,
                    patient_wound_visit_id_param INTEGER
                )
                RETURNS TABLE (
                    "InfectionStatus" BOOLEAN
                ) AS $$
                DECLARE
                    infection_status_result BOOLEAN := FALSE;
                    
                    -- Assessment flags
                    slow_healing_flag BOOLEAN := FALSE;
                    increased_pain_flag BOOLEAN := FALSE;
                    increased_exudate_flag BOOLEAN := FALSE;
                    swelling_flag BOOLEAN := FALSE;
                    redness_flag BOOLEAN := FALSE;
                    smell_flag BOOLEAN := FALSE;
                    warm_to_touch_flag BOOLEAN := FALSE;
                    
                    -- Current assessment variables
                    wound_id_var INTEGER;
                    visit_date_var TIMESTAMP;
                    suffering_var INTEGER;
                    exudate_var VARCHAR(30);
                    swelling_var BOOLEAN;
                    redness_var BOOLEAN;
                    smell_var BOOLEAN;
                    warm_to_touch_var BOOLEAN;
                    
                    -- Vital signs variables
                    vitalsign_id_var INTEGER;
                    temperature_var DECIMAL(6,2);
                    bp_sys_var INTEGER;
                    bp_dias_var INTEGER;
                    pr_var INTEGER;
                    
                    -- Previous assessment variables
                    prev_wound_visit_id_var INTEGER;
                    prev_suffering_var INTEGER;
                    prev_exudate_var VARCHAR(20);
                    
                    -- Wound measurement variables
                    prev_surface_area_var DECIMAL(6,2);
                    cur_surface_area_var DECIMAL(6,2);
                    prev_average_depth_var DECIMAL(6,2);
                    cur_average_depth_var DECIMAL(6,2);
                    
                    -- Exudate comparison variables
                    prev_exudate_value_var INTEGER := 0;
                    cur_exudate_value_var INTEGER := 0;
                    
                    -- Infection count
                    infection_items_count INTEGER := 0;
                BEGIN
                    -- Get current assessment
                    SELECT 
                        "VisitDate", 
                        "PatientWoundID_FK",
                        "Suffering",
                        "Exudate",
                        "IsSwelling",
                        "IsRedness",
                        "IsSmell",
                        "IsWarmToTouch"
                    INTO 
                        visit_date_var,
                        wound_id_var,
                        suffering_var,
                        exudate_var,
                        swelling_var,
                        redness_var,
                        smell_var,
                        warm_to_touch_var
                    FROM "PatientWoundVisit"
                    WHERE "PatientWoundVisitID" = patient_wound_visit_id_param 
                    AND "IsDeleted" = FALSE;
                
                    -- Early return if no wound found
                    IF wound_id_var IS NULL THEN
                        RETURN QUERY SELECT infection_status_result;
                        RETURN;
                    END IF;
                
                    -- Check if this is first visit with moderate or excessive exudate
                    IF (SELECT COUNT(1) 
                        FROM "PatientWoundVisit"
                        WHERE "IsDeleted" = FALSE 
                        AND "PatientWoundID_FK" = wound_id_var) = 1 
                    AND exudate_var IN ('Moderate ++', 'Excessive +++') THEN
                        RETURN QUERY SELECT TRUE;
                        RETURN;
                    END IF;
                
                    -- Get vital signs
                    SELECT "ID" INTO vitalsign_id_var
                    FROM "vitalsigns"
                    WHERE "patientid" = patient_id_param 
                    AND (DATE_TRUNC('day', "updatedDate") = DATE_TRUNC('day', visit_date_var)
                         OR DATE_TRUNC('day', "createdDate") = DATE_TRUNC('day', visit_date_var))
                    ORDER BY "createdDate" DESC
                    LIMIT 1;
                
                    -- Check vital signs if available
                    IF vitalsign_id_var IS NOT NULL THEN
                        SELECT "detailvalue" INTO temperature_var
                        FROM "VitalSignDetails"
                        WHERE "vitalSignTypeId" = 1 
                        AND "vitalsignid" = vitalsign_id_var;
                
                        IF temperature_var IS NOT NULL AND temperature_var > 38 THEN
                            -- Get BP and PR
                            SELECT 
                                MAX(CASE WHEN "vitalSignTypeId" = 2 THEN "detailValue" END),
                                MAX(CASE WHEN "vitalSignTypeId" = 3 THEN "detailValue" END),
                                MAX(CASE WHEN "vitalSignTypeId" = 6 THEN "detailValue" END)
                            INTO bp_sys_var, bp_dias_var, pr_var
                            FROM "VitalSignDetails"
                            WHERE "vitalsignid" = vitalsign_id_var
                            AND "vitalSignTypeId" IN (2, 3, 6);
                
                            IF (bp_sys_var IS NOT NULL AND (bp_sys_var > 140 OR bp_sys_var < 100)) OR
                               (bp_dias_var IS NOT NULL AND (bp_dias_var > 90 OR bp_dias_var < 60)) OR
                               (pr_var IS NOT NULL AND (pr_var > 100 OR pr_var < 50)) THEN
                                RETURN QUERY SELECT TRUE;
                                RETURN;
                            END IF;
                        END IF;
                    END IF;
                
                    -- Get wound measurements
                    SELECT "SurfaceArea", "AverageDepth"
                    INTO cur_surface_area_var, cur_average_depth_var
                    FROM "PatientWoundVisit"
                    WHERE "PatientWoundVisitID" = patient_wound_visit_id_param;
                
                    -- Get previous measurements
                    SELECT "SurfaceArea", "AverageDepth"
                    INTO prev_surface_area_var, prev_average_depth_var
                    FROM "PatientWoundVisit"
                    WHERE "PatientWoundID_FK" = wound_id_var
                    AND DATE_PART('day', visit_date_var - "VisitDate") >= 14
                    AND "SurfaceArea" < cur_surface_area_var
                    AND "AverageDepth" < cur_average_depth_var
                    ORDER BY "VisitDate" DESC
                    LIMIT 1;
                
                    -- Check for slow healing
                    IF prev_surface_area_var > 0 OR prev_average_depth_var > 0 THEN
                        slow_healing_flag := TRUE;
                        infection_items_count := infection_items_count + 1;
                    END IF;
                
                    -- Get previous assessment
                    SELECT 
                        "PatientWoundVisitID", 
                        "Suffering", 
                        "Exudate"
                    INTO 
                        prev_wound_visit_id_var,
                        prev_suffering_var,
                        prev_exudate_var
                    FROM "PatientWoundVisit"
                    WHERE "is_deleted" = FALSE
                    AND "PatientWoundID_FK" = wound_id_var
                    AND "VisitDate" < visit_date_var
                    AND "PatientWoundVisitID" != patient_wound_visit_id_param
                    ORDER BY "VisitDate" DESC
                    LIMIT 1;
                
                    -- Check for increased pain
                    IF prev_suffering_var IS NOT NULL AND suffering_var IS NOT NULL AND
                       (suffering_var > prev_suffering_var OR suffering_var > 3) THEN
                        increased_pain_flag := TRUE;
                        infection_items_count := infection_items_count + 1;
                    END IF;
                
                    -- Calculate exudate values
                    IF prev_exudate_var IS NOT NULL THEN
                        prev_exudate_value_var := CASE prev_exudate_var
                            WHEN 'Absent' THEN 0
                            WHEN 'Mild +' THEN 1
                            WHEN 'Moderate ++' THEN 2
                            WHEN 'Excessive +++' THEN 3
                            ELSE 0
                        END;
                    END IF;
                
                    IF exudate_var IS NOT NULL THEN
                        cur_exudate_value_var := CASE exudate_var
                            WHEN 'Absent' THEN 0
                            WHEN 'Mild +' THEN 1
                            WHEN 'Moderate ++' THEN 2
                            WHEN 'Excessive +++' THEN 3
                            ELSE 0
                        END;
                    END IF;
                
                    -- Check for increased exudate
                    IF cur_exudate_value_var > prev_exudate_value_var THEN
                        increased_exudate_flag := TRUE;
                        infection_items_count := infection_items_count + 1;
                    END IF;
                
                    -- Check other conditions
                    IF swelling_var IS NOT NULL AND swelling_var THEN
                        swelling_flag := TRUE;
                        infection_items_count := infection_items_count + 1;
                    END IF;
                
                    IF redness_var IS NOT NULL AND redness_var THEN
                        redness_flag := TRUE;
                        infection_items_count := infection_items_count + 1;
                    END IF;
                
                    IF smell_var IS NOT NULL AND smell_var THEN
                        smell_flag := TRUE;
                        infection_items_count := infection_items_count + 1;
                    END IF;
                
                    IF warm_to_touch_var IS NOT NULL AND warm_to_touch_var THEN
                        warm_to_touch_flag := TRUE;
                        infection_items_count := infection_items_count + 1;
                    END IF;
                
                    -- Set infection status if 3 or more conditions are met
                    IF infection_items_count >= 3 THEN
                        infection_status_result := TRUE;
                    END IF;
                
                    RETURN QUERY SELECT infection_status_result;
                END;
                $$ LANGUAGE plpgsql;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                DROP FUNCTION IF EXISTS "fn_SpGetWoundInfectionStatus";
                """);
        }
    }
}
