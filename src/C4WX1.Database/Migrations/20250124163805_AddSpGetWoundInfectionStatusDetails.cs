using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4WX1.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddSpGetWoundInfectionStatusDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE OR REPLACE FUNCTION "fn_SpGetWoundInfectionStatusDetails"(
                    user_id_param INTEGER,
                    patient_id_param INTEGER,
                    patient_wound_visit_id_param INTEGER
                ) RETURNS TABLE (
                    "InfectionStatus" BOOLEAN,
                    "infection_items_value" INTEGER,
                    "bSlowHealing" BOOLEAN,
                    "bIncreasedPain" BOOLEAN,
                    "bIncreasedExudate" BOOLEAN,
                    "bSwelling" BOOLEAN,
                    "bRedness" BOOLEAN,
                    "bSmell" BOOLEAN,
                    "bWarmToTouch" BOOLEAN,
                    "exudate_value" INTEGER,
                    "prev_exudate_value" INTEGER,
                    "PatientWoundVisitId" INTEGER,
                    "prev_exudate" VARCHAR(20),
                    "exudate" VARCHAR(30),
                    "BPDias" INTEGER,
                    "BPSys" INTEGER,
                    "PulseRate" INTEGER,
                    "Temperature" DECIMAL(6,2)
                ) AS $$
                DECLARE
                    b_infection_status BOOLEAN := FALSE;
                    b_slow_healing BOOLEAN := FALSE;
                    b_increased_pain BOOLEAN := FALSE;
                    b_increased_exudate BOOLEAN := FALSE;
                    b_swelling BOOLEAN := FALSE;
                    b_redness BOOLEAN := FALSE;
                    b_smell BOOLEAN := FALSE;
                    b_warm_to_touch BOOLEAN := FALSE;
                    
                    b_area_slow BOOLEAN;
                    b_depth_slow BOOLEAN;
                    
                    temp_val DECIMAL(6,2);
                    wound_id INTEGER;
                    suffering_val INTEGER;
                    exudate_val VARCHAR(30);
                    granulation_val DECIMAL(6,2);
                    epithelizing_val DECIMAL(6,2);
                    edges_val VARCHAR(30);
                    swelling_val BOOLEAN;
                    redness_val BOOLEAN;
                    smell_val BOOLEAN;
                    warm_to_touch_val BOOLEAN;
                    wound_visit_date TIMESTAMP;
                    vitalsign_id INTEGER;
                    bp_sys_val INTEGER;
                    bp_dias_val INTEGER;
                    pr_val INTEGER;
                    
                    prev_exudate_val VARCHAR(20);
                    prev_suffering_val INTEGER;
                    prev_wound_visit_id INTEGER;
                    granulation_epithelizing_val DECIMAL(6,2);
                    
                    -- Variables for surface area calculations
                    prev_surface_area DECIMAL(6,2);
                    cur_surface_area DECIMAL(6,2);
                    prev_average_depth DECIMAL(6,2);
                    cur_average_depth DECIMAL(6,2);
                    
                    exudate_val_int INTEGER := 0;
                    prev_exudate_val_int INTEGER := 0;
                    infection_items_val INTEGER := 0;
                BEGIN
                    -- Get current assessment
                    SELECT "VisitDate", "PatientWoundID_FK", "Suffering", "Exudate",
                           "TC_Granulation", "TC_Epithelizing", "Edges",
                           "IsSwelling", "IsRedness", "IsSmell", "IsWarmToTouch",
                           ("TC_Granulation" + "TC_Epithelizing")
                    INTO wound_visit_date, wound_id, suffering_val, exudate_val,
                         granulation_val, epithelizing_val, edges_val,
                         swelling_val, redness_val, smell_val, warm_to_touch_val,
                         granulation_epithelizing_val
                    FROM "PatientWoundVisit"
                    WHERE "PatientWoundVisitID" = patient_wound_visit_id_param AND NOT "IsDeleted";
                
                    IF wound_id IS NULL THEN
                        RETURN;
                    END IF;
                
                    -- Get vitalsign id
                    SELECT "id" INTO vitalsign_id
                    FROM "vitalsigns"
                    WHERE "patientid" = patient_id_param 
                    AND (DATE("updatedDate") = DATE(wound_visit_date) OR DATE("createdDate") = DATE(wound_visit_date))
                    ORDER BY "createdDate" DESC
                    LIMIT 1;
                
                    -- Check vital signs if available
                    IF vitalsign_id IS NOT NULL THEN
                        -- Get temperature
                        SELECT "detailvalue" INTO temp_val
                        FROM "VitalSignDetails" 
                        WHERE "vitalSignTypeId" = 1 AND "vitalsignid" = vitalsign_id;
                
                        IF temp_val IS NOT NULL AND temp_val > 38 THEN
                            -- Get BP and PR
                            SELECT "detailvalue" INTO bp_sys_val
                            FROM "VitalSignDetails" 
                            WHERE "vitalSignTypeId" = 2 AND "vitalsignid" = vitalsign_id;
                
                            SELECT "detailvalue" INTO bp_dias_val
                            FROM "VitalSignDetails" 
                            WHERE "vitalSignTypeId" = 3 AND "vitalsignid" = vitalsign_id;
                
                            SELECT "detailvalue" INTO pr_val
                            FROM "VitalSignDetails" 
                            WHERE "vitalSignTypeId" = 6 AND "vitalsignid" = vitalsign_id;
                
                            -- Check vital signs for infection status
                            IF bp_sys_val IS NOT NULL AND (bp_sys_val > 140 OR bp_sys_val < 100) THEN
                                b_infection_status := TRUE;
                            END IF;
                            
                            IF bp_dias_val IS NOT NULL AND (bp_dias_val > 90 OR bp_dias_val < 60) THEN
                                b_infection_status := TRUE;
                            END IF;
                
                            IF pr_val IS NOT NULL AND (pr_val > 100 OR pr_val < 50) THEN
                                b_infection_status := TRUE;
                            END IF;
                        END IF;
                    END IF;
                
                    -- Check slow healing
                    SELECT "SurfaceArea", "AverageDepth" 
                    INTO cur_surface_area, cur_average_depth
                    FROM "patientwoundvisit" 
                    WHERE "PatientWoundVisitID" = patient_wound_visit_id_param;
                
                    SELECT "SurfaceArea", "AverageDepth" 
                    INTO prev_surface_area, prev_average_depth
                    FROM "patientwoundvisit" 
                    WHERE "PatientWoundID_FK" = wound_id 
                    AND DATE("visitdate") <= (DATE(wound_visit_date) - INTERVAL '14 days')
                    AND "SurfaceArea" < cur_surface_area 
                    AND "AverageDepth" < cur_average_depth
                    ORDER BY "visitdate" DESC 
                    LIMIT 1;
                
                    IF prev_surface_area > 0 THEN 
                        b_area_slow := TRUE;
                    END IF;
                    
                    IF prev_average_depth > 0 THEN 
                        b_depth_slow := TRUE;
                    END IF;
                
                    IF b_area_slow OR b_depth_slow THEN 
                        b_slow_healing := TRUE;
                    END IF;
                
                    -- Get previous assessment
                    SELECT "PatientWoundVisitID", "Suffering", "Exudate"
                    INTO prev_wound_visit_id, prev_suffering_val, prev_exudate_val
                    FROM "patientwoundvisit"
                    WHERE NOT "IsDeleted" 
                    AND "patientwoundid_fk" = wound_id
                    AND "visitdate" < wound_visit_date
                    AND "patientwoundvisitid" <> patient_wound_visit_id_param
                    ORDER BY "visitdate" DESC
                    LIMIT 1;
                
                    -- Check increased pain
                    IF prev_suffering_val IS NOT NULL AND suffering_val IS NOT NULL THEN
                        IF suffering_val > prev_suffering_val OR suffering_val > 3 THEN
                            b_increased_pain := TRUE;
                        END IF;
                    END IF;
                
                    -- Check increased exudate
                    IF prev_exudate_val IS NOT NULL THEN
                        prev_exudate_val_int := CASE prev_exudate_val
                            WHEN 'Absent' THEN 0
                            WHEN 'Mild +' THEN 1
                            WHEN 'Moderate ++' THEN 2
                            WHEN 'Excessive +++' THEN 3
                            ELSE 0
                        END;
                    END IF;
                
                    IF exudate_val IS NOT NULL THEN
                        exudate_val_int := CASE exudate_val
                            WHEN 'Absent' THEN 0
                            WHEN 'Mild +' THEN 1
                            WHEN 'Moderate ++' THEN 2
                            WHEN 'Excessive +++' THEN 3
                            ELSE 0
                        END;
                    END IF;
                
                    IF exudate_val_int > prev_exudate_val_int THEN
                        b_increased_exudate := TRUE;
                    END IF;
                
                    -- Check other symptoms
                    IF swelling_val THEN
                        b_swelling := TRUE;
                    END IF;
                
                    IF redness_val THEN
                        b_redness := TRUE;
                    END IF;
                
                    IF smell_val THEN
                        b_smell := TRUE;
                    END IF;
                
                    IF warm_to_touch_val THEN
                        b_warm_to_touch := TRUE;
                    END IF;
                
                    -- Calculate infection items value
                    infection_items_val := (
                        b_slow_healing::INT + 
                        b_increased_pain::INT + 
                        b_increased_exudate::INT + 
                        b_swelling::INT +
                        b_redness::INT + 
                        b_smell::INT + 
                        b_warm_to_touch::INT
                    );
                
                    IF infection_items_val >= 3 THEN
                        b_infection_status := TRUE;
                    END IF;
                
                    -- Check first visit exudate
                    IF NOT b_infection_status THEN
                        IF (SELECT COUNT(*) 
                            FROM "patientwoundvisit"
                            WHERE NOT "IsDeleted" AND "PatientWoundID_FK" = wound_id) = 1
                        AND exudate_val IN ('Moderate ++', 'Excessive +++') THEN
                            b_infection_status := TRUE;
                        END IF;
                    END IF;
                
                    RETURN QUERY 
                    SELECT 
                        b_infection_status,
                        infection_items_val,
                        b_slow_healing,
                        b_increased_pain,
                        b_increased_exudate,
                        b_swelling,
                        b_redness,
                        b_smell,
                        b_warm_to_touch,
                        exudate_val_int,
                        prev_exudate_val_int,
                        patient_wound_visit_id_param,
                        prev_exudate_val,
                        exudate_val,
                        bp_dias_val,
                        bp_sys_val,
                        pr_val,
                        temp_val;
                END;
                $$ LANGUAGE plpgsql;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                DROP FUNCTION IF EXISTS "fn_SpGetWoundInfectionStatusDetails";
                """);
        }
    }
}
