using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4WX1.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddSpCreatePatientWound : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE OR REPLACE FUNCTION "fn_SpCreatePatientWound"(
                    patient_id_param INTEGER
                ) 
                RETURNS TEXT
                LANGUAGE plpgsql
                AS $$
                DECLARE
                    patient_wound_id_var INTEGER;
                    vital_sign_id_var INTEGER;
                    patient_wound_visit_id_var INTEGER;
                    patient_wound_visit_appearance_id_var INTEGER;
                    item_id_var INTEGER;
                    wound_status_id_var INTEGER;
                BEGIN
                    -- Check if patient exists
                    IF EXISTS (SELECT 1 FROM "Patient" WHERE "PatientID" = patient_id_param) THEN
                        -- Get wound status ID
                        SELECT "CodeId" INTO wound_status_id_var
                        FROM "Code"
                        WHERE "CodeTypeId_FK" = 301 
                        AND NOT "IsDeleted"
                        AND "CodeName" = 'Acute';
                
                        -- Insert patient wound
                        INSERT INTO "PatientWound" (
                            "PatientID_FK",
                            "OccurDate",
                            "SeenDate",
                            "Site",
                            "IsDeleted",
                            "CreatedDate",
                            "CreatedBy_FK",
                            "LocationOfWound",
                            "ActionDescription",
                            "Category",
                            "Stage",
                            "WoundStatusID_FK"
                        )
                        VALUES (
                            patient_id_param,
                            CURRENT_TIMESTAMP,
                            CURRENT_TIMESTAMP,
                            'N.A.',
                            FALSE,
                            CURRENT_TIMESTAMP,
                            1,
                            'Sacral',
                            'Auto Creation Wound',
                            'Diabetic Ulcers',
                            'Diabetic Ulcers Stage 1',
                            wound_status_id_var
                        )
                        RETURNING "PatientWoundID" INTO patient_wound_id_var;
                
                        -- Insert vital signs
                        INSERT INTO "VitalSigns" (
                            "patientId",
                            "source",
                            "icaId",
                            "isDeleted",
                            "createdBy",
                            "createdDate"
                        )
                        VALUES (
                            patient_id_param,
                            'Patient Wound',
                            0,
                            FALSE,
                            1,
                            CURRENT_TIMESTAMP
                        )
                        RETURNING "VitalSignID" INTO vital_sign_id_var;
                
                        -- Insert patient wound visit
                        INSERT INTO "PatientWoundVisit" (
                            "PatientWoundID_FK",
                            "VisitDate",
                            "WoundType",
                            "WoundSubType",
                            "SizeLength",
                            "SizeDepth",
                            "SizeWidth",
                            "Edges",
                            "Smell",
                            "UnderMining",
                            "Suffering",
                            "ImageUpload",
                            "VitalSignID_FK",
                            "IsDeleted",
                            "CreatedDate",
                            "CreatedBy_FK",
                            "DESIGN_R_Depth",
                            "DESIGN_R_Exudate",
                            "DESIGN_R_Size",
                            "DESIGN_R_Inflammation",
                            "DESIGN_R_Granulation",
                            "DESIGN_R_Necrotic",
                            "DESIGN_R_Pocket",
                            "DESIGN_R_Score",
                            "IsDESIGN_R",
                            "PeriWound",
                            "Debridement",
                            "CleansingSolutionUsed",
                            "IsDraft",
                            "ExudateSubInfo",
                            "Exudate",
                            "TC_Granulation",
                            "TC_Slough",
                            "TC_Necrosis",
                            "TC_Epithelizing",
                            "TC_Others",
                            "Perimeter",
                            "MaximumDepth",
                            "IsRedness",
                            "IsSwelling",
                            "IsWarmToTouch",
                            "IsSmell",
                            "TC_Auto_Granulation",
                            "TC_Auto_Slough",
                            "TC_Auto_Necrosis",
                            "TC_Auto_Epithelizing",
                            "TC_Auto_Others",
                            "AssignedToID_FK"
                        )
                        VALUES (
                            patient_wound_id_var,
                            CURRENT_TIMESTAMP,
                            'Diabetic Ulcers',
                            'Diabetic Ulcers Stage 1',
                            0, 0, 0,
                            'Healthy',
                            'Absent',
                            'NA',
                            0,
                            'WoundDefaultImage.jpg',
                            vital_sign_id_var,
                            FALSE,
                            CURRENT_TIMESTAMP,
                            1,
                            0, 0, 0, 0, 0, 0, 0, 0,
                            FALSE,
                            'Healthy',
                            'Not Performed',
                            'Betadine',
                            FALSE,
                            'Absent',
                            'Absent',
                            0, 0, 0, 0, 0, 0, 0,
                            FALSE, FALSE, FALSE, FALSE,
                            0, 0, 0, 0, 0,
                            1
                        )
                        RETURNING "PatientWoundVisitID" INTO patient_wound_visit_id_var;
                
                        -- Get wound visit appearance ID
                        SELECT "CodeId" INTO patient_wound_visit_appearance_id_var
                        FROM "Code"
                        WHERE "CodeTypeId_FK" = 65 
                        AND "CodeName" = 'Granulation'
                        AND NOT "IsDeleted";
                
                        -- Insert patient wound visit appearance
                        INSERT INTO "PatientWoundVisitAppearance" (
                            "PatientWoundVisitID_FK",
                            "CodeID_FK"
                        )
                        VALUES (
                            patient_wound_visit_id_var,
                            patient_wound_visit_appearance_id_var
                        );
                
                        -- Get item ID and insert treatment
                        SELECT "ItemID" INTO item_id_var
                        FROM "Item"
                        WHERE "ItemName" = 'Acticoat'
                        AND NOT "IsDeleted";
                
                        INSERT INTO "PatientWoundVisitTreatment" (
                            "PatientWoundVisitID_FK",
                            "ItemID_FK",
                            "Quantity",
                            "IsChargeable",
                            "IsDeleted",
                            "CreatedDate",
                            "CreatedBy_FK"
                        )
                        VALUES (
                            patient_wound_visit_id_var,
                            item_id_var,
                            1,
                            TRUE,
                            FALSE,
                            CURRENT_TIMESTAMP,
                            1
                        );
                
                        RETURN 'New Wound has been Created for PatientID = ' || patient_id_param;
                    ELSE
                        RETURN 'PatientID not Found, ' || patient_id_param;
                    END IF;
                END;
                $$;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                DROP FUNCTION IF EXISTS "fn_SpCreatePatientWound";
                """);
        }
    }
}
