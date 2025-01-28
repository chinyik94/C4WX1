using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4WX1.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddVwCarePlanSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE OR REPLACE VIEW "vw_DiseaseCarePlanSetup" AS
                SELECT 
                    "p"."PatientID",
                    "p"."Lastname",
                    "p"."Firstname",
                    "ica"."InitialCareAssessmentID",
                    "d"."DiseaseID",
                    "d"."DiseaseName",
                    "d"."SystemID_FK",
                    "sfd"."System",
                    "ica"."Status",
                    "ica"."IsDeleted",
                    "dsi"."DiseaseSubInfoID",
                    "dsi"."DiseaseSubInfo"
                FROM "Patient" "p"
                INNER JOIN "InitialCareAssessment" "ica" 
                    ON "ica"."PatientID_FK" = "p"."PatientID" 
                    AND ("ica"."Status" = 'Active' OR "ica"."Status" = 'Submitted')
                INNER JOIN "PatientReferral" "pr" 
                    ON "ica"."PatientReferralID_FK" = "pr"."PatientReferralID"
                INNER JOIN "PatientClinician" "pc" 
                    ON "pr"."PrimaryClinicianID_FK" = "pc"."PatientClinicianID"
                INNER JOIN "Disease" "d" 
                    ON "d"."DiseaseID" = "pc"."DiseaseID_FK" 
                    AND "d"."SystemID_FK" NOT IN (
                        SELECT "SystemID" 
                        FROM "SystemForDisease" 
                        WHERE "System" = 'Family History'
                    )
                LEFT JOIN "DiseaseSubInfo" "dsi" 
                    ON "d"."DiseaseID" = "dsi"."DiseaseID_FK" 
                    AND "dsi"."DiseaseSubInfoID" = "pc"."DiseaseSubInfoID_FK"
                LEFT JOIN "SystemForDisease" "sfd" 
                    ON "d"."SystemID_FK" = "sfd"."SystemID"

                UNION

                SELECT 
                    "p"."PatientID",
                    "p"."Lastname",
                    "p"."Firstname",
                    "ica"."InitialCareAssessmentID",
                    "d"."DiseaseID",
                    "d"."DiseaseName",
                    "d"."SystemID_FK",
                    "sfd"."System",
                    "ica"."Status",
                    "ica"."IsDeleted",
                    "dsi"."DiseaseSubInfoID",
                    "dsi"."DiseaseSubInfo"
                FROM "Patient" "p"
                INNER JOIN "InitialCareAssessment" "ica" 
                    ON "ica"."PatientID_FK" = "p"."PatientID" 
                    AND ("ica"."Status" = 'Active' OR "ica"."Status" = 'Submitted')
                INNER JOIN "PatientReferral" "pr" 
                    ON "ica"."PatientReferralID_FK" = "pr"."PatientReferralID"
                INNER JOIN "PatientClinician" "pc" 
                    ON "pr"."SecondaryClinicianID_FK" = "pc"."PatientClinicianID"
                INNER JOIN "Disease" "d" 
                    ON "d"."DiseaseID" = "pc"."DiseaseID_FK" 
                    AND "d"."SystemID_FK" NOT IN (
                        SELECT "SystemID" 
                        FROM "SystemForDisease" 
                        WHERE "System" = 'Family History'
                    )
                LEFT JOIN "DiseaseSubInfo" "dsi" 
                    ON "d"."DiseaseID" = "dsi"."DiseaseID_FK" 
                    AND "dsi"."DiseaseSubInfoID" = "pc"."DiseaseSubInfoID_FK"
                LEFT JOIN "SystemForDisease" "sfd" 
                    ON "d"."SystemID_FK" = "sfd"."SystemID";

                CREATE OR REPLACE VIEW "vw_MedicalHistoryCarePlanSetup" AS
                SELECT 
                    "p"."PatientID",
                    "p"."Lastname",
                    "p"."Firstname",
                    "ica"."InitialCareAssessmentID",
                    "d"."DiseaseID",
                    "d"."DiseaseName",
                    "d"."SystemID_FK",
                    "sfd"."System",
                    "ica"."Status",
                    "ica"."IsDeleted",
                    "dsi"."DiseaseSubInfoID",
                    "dsi"."DiseaseSubInfo"
                FROM "Patient" "p"
                INNER JOIN "InitialCareAssessment" "ica" 
                    ON "ica"."PatientID_FK" = "p"."PatientID" 
                    AND ("ica"."Status" = 'Active' OR "ica"."Status" = 'Submitted')
                INNER JOIN "PatientMedicalHistory" "pmh" 
                    ON "ica"."InitialCareAssessmentID" = "pmh"."InitialCareAssessmentID_FK"
                INNER JOIN "PatientClinician" "pc" 
                    ON "pmh"."ClinicianID_FK" = "pc"."PatientClinicianID"
                INNER JOIN "Disease" "d" 
                    ON "d"."DiseaseID" = "pc"."DiseaseID_FK" 
                    AND "d"."SystemID_FK" NOT IN (
                        SELECT "SystemID" 
                        FROM "SystemForDisease" 
                        WHERE "System" = 'Family History'
                    )
                LEFT JOIN "DiseaseSubInfo" "dsi" 
                    ON "d"."DiseaseID" = "dsi"."DiseaseID_FK" 
                    AND "dsi"."DiseaseSubInfoID" = "pc"."DiseaseSubInfoID_FK"
                LEFT JOIN "SystemForDisease" "sfd" 
                    ON "d"."SystemID_FK" = "sfd"."SystemID";

                CREATE OR REPLACE VIEW "vw_AmtCarePlanSetup" AS
                SELECT 
                    "p"."PatientID",
                    "p"."Lastname",
                    "p"."Firstname",
                    "ica"."InitialCareAssessmentID",
                    "d"."DiseaseID",
                    "d"."DiseaseName",
                    "d"."SystemID_FK",
                    "sfd"."System",
                    "ica"."Status",
                    "ica"."IsDeleted",
                    "dsi"."DiseaseSubInfoID",
                    "dsi"."DiseaseSubInfo"
                FROM "Patient" "p"
                INNER JOIN "InitialCareAssessment" "ica" 
                    ON "ica"."PatientID_FK" = "p"."PatientID" 
                    AND ("ica"."Status" = 'Active' OR "ica"."Status" = 'Submitted')
                INNER JOIN "PatientAMT" "pamt" 
                    ON "ica"."InitialCareAssessmentID" = "pamt"."InitialCareAssessmentID_FK" 
                    AND "pamt"."Score" >= 7
                INNER JOIN "Disease" "d" 
                    ON "d"."DiseaseID" = 100000 -- Cognitive Impairment
                LEFT JOIN "DiseaseSubInfo" "dsi" 
                    ON "d"."DiseaseID" = "dsi"."DiseaseID_FK"
                LEFT JOIN "SystemForDisease" "sfd" 
                    ON "d"."SystemID_FK" = "sfd"."SystemID";

                CREATE OR REPLACE VIEW "vw_BradenScaleCarePlanSetup" AS
                SELECT 
                    "p"."PatientID",
                    "p"."Lastname",
                    "p"."Firstname",
                    "ica"."InitialCareAssessmentID",
                    "d"."DiseaseID",
                    "d"."DiseaseName",
                    "d"."SystemID_FK",
                    "sfd"."System",
                    "ica"."Status",
                    "ica"."IsDeleted",
                    "dsi"."DiseaseSubInfoID",
                    "dsi"."DiseaseSubInfo"
                FROM "Patient" "p"
                INNER JOIN "InitialCareAssessment" "ica" 
                    ON "p"."PatientID" = "ica"."PatientID_FK"
                    AND ("ica"."Status" = 'Active' OR "ica"."Status" = 'Submitted')
                    AND (
                        "ica"."WoundAssessmentScore1" +
                        "ica"."WoundAssessmentScore2" +
                        "ica"."WoundAssessmentScore3" +
                        "ica"."WoundAssessmentScore4" +
                        "ica"."WoundAssessmentScore5" +
                        "ica"."WoundAssessmentScore6"
                    ) < 19
                INNER JOIN "Disease" "d" 
                    ON "d"."DiseaseID" = 100001 -- Impaired Skin Integrity
                LEFT JOIN "DiseaseSubInfo" "dsi" 
                    ON "d"."DiseaseID" = "dsi"."DiseaseID_FK"
                LEFT JOIN "SystemForDisease" "sfd" 
                    ON "d"."SystemID_FK" = "sfd"."SystemID";

                CREATE OR REPLACE VIEW "vw_OralCarePlanSetup" AS
                SELECT 
                    "p"."PatientID",
                    "p"."Lastname",
                    "p"."Firstname",
                    "ica"."InitialCareAssessmentID",
                    "d"."DiseaseID",
                    "d"."DiseaseName",
                    "d"."SystemID_FK",
                    "sfd"."System",
                    "ica"."Status",
                    "ica"."IsDeleted",
                    "dsi"."DiseaseSubInfoID",
                    "dsi"."DiseaseSubInfo"
                FROM "Patient" "p"
                INNER JOIN "InitialCareAssessment" "ica" 
                    ON "p"."PatientID" = "ica"."PatientID_FK"
                    AND ("ica"."Status" = 'Active' OR "ica"."Status" = 'Submitted')
                    AND (
                        "ica"."OralCavityAssessmentScore1" +
                        "ica"."OralCavityAssessmentScore2" +
                        "ica"."OralCavityAssessmentScore3" +
                        "ica"."OralCavityAssessmentScore4" +
                        "ica"."OralCavityAssessmentScore5" +
                        "ica"."OralCavityAssessmentScore6"
                    ) BETWEEN 6 AND 11
                INNER JOIN "Disease" "d" 
                    ON "d"."DiseaseID" = 100002 -- Mild dysfunction of the oral cavity
                LEFT JOIN "DiseaseSubInfo" "dsi" 
                    ON "d"."DiseaseID" = "dsi"."DiseaseID_FK"
                LEFT JOIN "SystemForDisease" "sfd" 
                    ON "d"."SystemID_FK" = "sfd"."SystemID"

                UNION

                SELECT 
                    "p"."PatientID",
                    "p"."Lastname",
                    "p"."Firstname",
                    "ica"."InitialCareAssessmentID",
                    "d"."DiseaseID",
                    "d"."DiseaseName",
                    "d"."SystemID_FK",
                    "sfd"."System",
                    "ica"."Status",
                    "ica"."IsDeleted",
                    "dsi"."DiseaseSubInfoID",
                    "dsi"."DiseaseSubInfo"
                FROM "Patient" "p"
                INNER JOIN "InitialCareAssessment" "ica" 
                    ON "p"."PatientID" = "ica"."PatientID_FK"
                    AND ("ica"."Status" = 'Active' OR "ica"."Status" = 'Submitted')
                    AND (
                        "ica"."OralCavityAssessmentScore1" +
                        "ica"."OralCavityAssessmentScore2" +
                        "ica"."OralCavityAssessmentScore3" +
                        "ica"."OralCavityAssessmentScore4" +
                        "ica"."OralCavityAssessmentScore5" +
                        "ica"."OralCavityAssessmentScore6"
                    ) BETWEEN 12 AND 18
                INNER JOIN "Disease" "d" 
                    ON "d"."DiseaseID" = 100003 -- Moderate dysfunction of the oral cavity
                LEFT JOIN "DiseaseSubInfo" "dsi" 
                    ON "d"."DiseaseID" = "dsi"."DiseaseID_FK"
                LEFT JOIN "SystemForDisease" "sfd" 
                    ON "d"."SystemID_FK" = "sfd"."SystemID"

                UNION

                SELECT 
                    "p"."PatientID",
                    "p"."Lastname",
                    "p"."Firstname",
                    "ica"."InitialCareAssessmentID",
                    "d"."DiseaseID",
                    "d"."DiseaseName",
                    "d"."SystemID_FK",
                    "sfd"."System",
                    "ica"."Status",
                    "ica"."IsDeleted",
                    "dsi"."DiseaseSubInfoID",
                    "dsi"."DiseaseSubInfo"
                FROM "Patient" "p"
                INNER JOIN "InitialCareAssessment" "ica" 
                    ON "p"."PatientID" = "ica"."PatientID_FK"
                    AND ("ica"."Status" = 'Active' OR "ica"."Status" = 'Submitted')
                    AND (
                        "ica"."OralCavityAssessmentScore1" +
                        "ica"."OralCavityAssessmentScore2" +
                        "ica"."OralCavityAssessmentScore3" +
                        "ica"."OralCavityAssessmentScore4" +
                        "ica"."OralCavityAssessmentScore5" +
                        "ica"."OralCavityAssessmentScore6"
                    ) BETWEEN 19 AND 25
                INNER JOIN "Disease" "d" 
                    ON "d"."DiseaseID" = 100004 -- Severe dysfunction of the oral cavity
                LEFT JOIN "DiseaseSubInfo" "dsi" 
                    ON "d"."DiseaseID" = "dsi"."DiseaseID_FK"
                LEFT JOIN "SystemForDisease" "sfd" 
                    ON "d"."SystemID_FK" = "sfd"."SystemID";

                CREATE OR REPLACE VIEW "vw_RafCarePlanSetup" AS
                SELECT 
                    "p"."PatientID",
                    "p"."Lastname",
                    "p"."Firstname",
                    "ica"."InitialCareAssessmentID",
                    "d"."DiseaseID",
                    "d"."DiseaseName",
                    "d"."SystemID_FK",
                    "sfd"."System",
                    "ica"."Status",
                    "ica"."IsDeleted",
                    "dsi"."DiseaseSubInfoID",
                    "dsi"."DiseaseSubInfo"
                FROM "Patient" "p"
                INNER JOIN "InitialCareAssessment" "ica" 
                    ON "p"."PatientID" = "ica"."PatientID_FK"
                    AND ("ica"."Status" = 'Active' OR "ica"."Status" = 'Submitted')
                    AND (
                        "ica"."WoundAssessmentScore1" +
                        "ica"."WoundAssessmentScore2" +
                        "ica"."WoundAssessmentScore3" +
                        "ica"."WoundAssessmentScore4" +
                        "ica"."WoundAssessmentScore5" +
                        "ica"."WoundAssessmentScore6"
                    ) < 19
                INNER JOIN "PatientRAF" "raf" 
                    ON "ica"."PatientRAFID_FK" = "raf"."PatientRAFID"
                INNER JOIN "Disease" "d" 
                    ON "d"."DiseaseID" = 104 -- Impaired physical mobility
                LEFT JOIN "DiseaseSubInfo" "dsi" 
                    ON "d"."DiseaseID" = "dsi"."DiseaseID_FK"
                LEFT JOIN "SystemForDisease" "sfd" 
                    ON "d"."SystemID_FK" = "sfd"."SystemID"
                WHERE "raf"."Score1" >= 3;

                CREATE OR REPLACE VIEW "vw_NursingDiagnosesCarePlanSetup" AS
                 -- 1. Nursing Diagnosis Pain with Pain Score >= 2
                      SELECT
                          "p"."PatientID",
                          "p"."Lastname",
                          "p"."Firstname",
                          "ica"."InitialCareAssessmentID",
                          "d"."DiseaseID",
                          "d"."DiseaseName",
                          "d"."SystemID_FK",
                          "sfd"."System",
                          "ica"."Status",
                          "ica"."IsDeleted",
                          "dsi"."DiseaseSubInfoID",
                          "dsi"."DiseaseSubInfo"
                      FROM "Patient" "p"
                      INNER JOIN "InitialCareAssessment" "ica"
                          ON "ica"."PatientID_FK" = "p"."PatientID"
                          AND ("ica"."Status" = 'Active' OR "ica"."Status" = 'Submitted')
                      INNER JOIN "Disease" "d"
                          ON "d"."DiseaseName" = 'Pain'
                      INNER JOIN "VitalSigns" "vs"
                          ON "vs"."icaId" = "ica"."InitialCareAssessmentID"
                      INNER JOIN "VitalSignDetails" "vsd"
                          ON "vsd"."vitalSignId" = "vs"."id"
                          AND "vsd"."vitalSignTypeId" = 9
                          AND "vsd"."detailValue" >= 2
                      LEFT JOIN "DiseaseSubInfo" "dsi"
                          ON "d"."DiseaseID" = "dsi"."DiseaseID_FK"
                      INNER JOIN "SystemForDisease" "sfd"
                          ON "d"."SystemID_FK" = "sfd"."SystemID"
                          AND "sfd"."System" = 'General Nursing Diagnoses'

                      UNION

                      -- 2. Nursing Diagnosis Ineffective Therapeutic Regimen Management
                      SELECT
                          "p"."PatientID",
                          "p"."Lastname",
                          "p"."Firstname",
                          "ica"."InitialCareAssessmentID",
                          "d"."DiseaseID",
                          "d"."DiseaseName",
                          "d"."SystemID_FK",
                          "sfd"."System",
                          "ica"."Status",
                          "ica"."IsDeleted",
                          "dsi"."DiseaseSubInfoID",
                          "dsi"."DiseaseSubInfo"
                      FROM "Patient" "p"
                      INNER JOIN "InitialCareAssessment" "ica"
                          ON "ica"."PatientID_FK" = "p"."PatientID"
                          AND ("ica"."Status" = 'Active' OR "ica"."Status" = 'Submitted')
                      INNER JOIN "Disease" "d"
                          ON "d"."DiseaseName" = 'Ineffective Therapeutic Regimen Management'
                      INNER JOIN "PatientMedication" "pm"
                          ON "ica"."PatientMedicationID_FK" = "pm"."PatientMedicationID"
                          AND "pm"."Compliant" IS TRUE
                      LEFT JOIN "DiseaseSubInfo" "dsi"
                          ON "d"."DiseaseID" = "dsi"."DiseaseID_FK"
                      INNER JOIN "SystemForDisease" "sfd"
                          ON "d"."SystemID_FK" = "sfd"."SystemID"
                          AND "sfd"."System" = 'General Nursing Diagnoses'

                      UNION

                      -- 3. Nursing Diagnosis Risk for Falls (VisionSpectacles)
                      SELECT
                          "p"."PatientID",
                          "p"."Lastname",
                          "p"."Firstname",
                          "ica"."InitialCareAssessmentID",
                          "d"."DiseaseID",
                          "d"."DiseaseName",
                          "d"."SystemID_FK",
                          "sfd"."System",
                          "ica"."Status",
                          "ica"."IsDeleted",
                          "dsi"."DiseaseSubInfoID",
                          "dsi"."DiseaseSubInfo"
                      FROM "Patient" "p"
                      INNER JOIN "InitialCareAssessment" "ica"
                          ON "ica"."PatientID_FK" = "p"."PatientID"
                          AND ("ica"."Status" = 'Active' OR "ica"."Status" = 'Submitted')
                      INNER JOIN "Disease" "d"
                          ON "d"."DiseaseName" = 'Risk for fall'
                      LEFT JOIN "DiseaseSubInfo" "dsi"
                          ON "d"."DiseaseID" = "dsi"."DiseaseID_FK"
                      INNER JOIN "SystemForDisease" "sfd"
                          ON "d"."SystemID_FK" = "sfd"."SystemID"
                          AND "sfd"."System" = 'General Nursing Diagnoses'
                      WHERE "ica"."Vision" <> 'Normal'
                        AND "ica"."VisionSpectacles" IS FALSE

                      UNION

                      -- 4. Nursing Diagnosis Risk for Falls (HearingAid)
                      SELECT
                          "p"."PatientID",
                          "p"."Lastname",
                          "p"."Firstname",
                          "ica"."InitialCareAssessmentID",
                          "d"."DiseaseID",
                          "d"."DiseaseName",
                          "d"."SystemID_FK",
                          "sfd"."System",
                          "ica"."Status",
                          "ica"."IsDeleted",
                          "dsi"."DiseaseSubInfoID",
                          "dsi"."DiseaseSubInfo"
                      FROM "Patient" "p"
                      INNER JOIN "InitialCareAssessment" "ica"
                          ON "ica"."PatientID_FK" = "p"."PatientID"
                          AND ("ica"."Status" = 'Active' OR "ica"."Status" = 'Submitted')
                      INNER JOIN "Disease" "d"
                          ON "d"."DiseaseName" = 'Risk for fall'
                      LEFT JOIN "DiseaseSubInfo" "dsi"
                          ON "d"."DiseaseID" = "dsi"."DiseaseID_FK"
                      INNER JOIN "SystemForDisease" "sfd"
                          ON "d"."SystemID_FK" = "sfd"."SystemID"
                          AND "sfd"."System" = 'General Nursing Diagnoses'
                      WHERE "ica"."Hearing" <> 'Normal'
                        AND "ica"."HearingAid" IS FALSE

                      UNION

                      -- 5. If tracheostomy is selected, Care Plan for Tracheostomy is activated
                      SELECT
                          "p"."PatientID",
                          "p"."Lastname",
                          "p"."Firstname",
                          "ica"."InitialCareAssessmentID",
                          "d"."DiseaseID",
                          "d"."DiseaseName",
                          "d"."SystemID_FK",
                          "sfd"."System",
                          "ica"."Status",
                          "ica"."IsDeleted",
                          "dsi"."DiseaseSubInfoID",
                          "dsi"."DiseaseSubInfo"
                      FROM "Patient" "p"
                      INNER JOIN "InitialCareAssessment" "ica"
                          ON "ica"."PatientID_FK" = "p"."PatientID"
                          AND ("ica"."Status" = 'Active' OR "ica"."Status" = 'Submitted')
                      INNER JOIN "SystemForDisease" "sfd"
                          ON "sfd"."System" = 'Tracheostomy Care'
                      INNER JOIN "Disease" "d"
                          ON "d"."SystemID_FK" = "sfd"."SystemID"
                      LEFT JOIN "DiseaseSubInfo" "dsi"
                          ON "d"."DiseaseID" = "dsi"."DiseaseID_FK"
                      WHERE "ica"."OxygenRequired" IS TRUE
                          AND "ica"."OxygenType" = 'Tracheostomy'

                      UNION

                      -- 7. If "immediate" is not the one selected, Nursing Diagnosis for Deficient fluid volume is activated
                      SELECT
                          "p"."PatientID",
                          "p"."Lastname",
                          "p"."Firstname",
                          "ica"."InitialCareAssessmentID",
                          "d"."DiseaseID",
                          "d"."DiseaseName",
                          "d"."SystemID_FK",
                          "sfd"."System",
                          "ica"."Status",
                          "ica"."IsDeleted",
                          "dsi"."DiseaseSubInfoID",
                          "dsi"."DiseaseSubInfo"
                      FROM "Patient" "p"
                      INNER JOIN "InitialCareAssessment" "ica"
                          ON "ica"."PatientID_FK" = "p"."PatientID"
                          AND ("ica"."Status" = 'Active' OR "ica"."Status" = 'Submitted')
                      INNER JOIN "Disease" "d"
                          ON "d"."DiseaseName" = 'Deficient fluid volume'
                      LEFT JOIN "DiseaseSubInfo" "dsi"
                          ON "d"."DiseaseID" = "dsi"."DiseaseID_FK"
                      INNER JOIN "SystemForDisease" "sfd"
                          ON "d"."SystemID_FK" = "sfd"."SystemID"
                          AND "sfd"."System" = 'General Nursing Diagnoses'
                      WHERE "ica"."SkinTurgor" IS NOT NULL
                          AND "ica"."SkinTurgor" <> 'Immediate'

                      UNION

                      -- 8. If anything other than Normal is selected, Nursing Diagnosis for Risk of Impaired Skin Integrity is activated
                      SELECT
                          "p"."PatientID",
                          "p"."Lastname",
                          "p"."Firstname",
                          "ica"."InitialCareAssessmentID",
                          "d"."DiseaseID",
                          "d"."DiseaseName",
                          "d"."SystemID_FK",
                          "sfd"."System",
                          "ica"."Status",
                          "ica"."IsDeleted",
                          "dsi"."DiseaseSubInfoID",
                          "dsi"."DiseaseSubInfo"
                      FROM "Patient" "p"
                      INNER JOIN "InitialCareAssessment" "ica"
                          ON "ica"."PatientID_FK" = "p"."PatientID"
                          AND ("ica"."Status" = 'Active' OR "ica"."Status" = 'Submitted')
                      INNER JOIN "Disease" "d"
                          ON "d"."DiseaseName" = 'Risk for impaired skin integrity'
                      LEFT JOIN "DiseaseSubInfo" "dsi"
                          ON "d"."DiseaseID" = "dsi"."DiseaseID_FK"
                      INNER JOIN "SystemForDisease" "sfd"
                          ON "d"."SystemID_FK" = "sfd"."SystemID"
                          AND "sfd"."System" = 'General Nursing Diagnoses'
                      WHERE "ica"."SkinType" IS NOT NULL
                          AND "ica"."SkinType" <> 'Normal'

                      UNION

                      -- 10. If Yes selected, Care Plan for Wound Care is activated
                      -- Pressure Injuries (InitialCareAssessment, PressureInjuries)
                      SELECT p."PatientID", p."Lastname", p."Firstname", ica."InitialCareAssessmentID", d."DiseaseID", d."DiseaseName", d."SystemID_FK", sfd."System", ica."Status", ica."IsDeleted", dsi."DiseaseSubInfoID", dsi."DiseaseSubInfo"
                      FROM "Patient" p
                      INNER JOIN "InitialCareAssessment" ica ON ica."PatientID_FK" = p."PatientID" AND (ica."Status" = 'Active' OR ica."Status" = 'Submitted')
                      INNER JOIN "SystemForDisease" sfd ON sfd."System" = 'Wound Care'
                      INNER JOIN "Disease" d ON d."SystemID_FK" = sfd."SystemID"
                      LEFT JOIN "DiseaseSubInfo" dsi ON d."DiseaseID" = dsi."DiseaseID_FK"
                      WHERE ica."PressureInjuries" IS TRUE

                      UNION

                      -- 11. Anything other than Independent selected, Nursing Diagnosis of Risk for fall is activated
                      -- Mobility status (InitialCareAssessment, MobilityStatus)
                      SELECT p."PatientID", p."Lastname", p."Firstname", ica."InitialCareAssessmentID", d."DiseaseID", d."DiseaseName", d."SystemID_FK", sfd."System", ica."Status", ica."IsDeleted", dsi."DiseaseSubInfoID", dsi."DiseaseSubInfo"
                      FROM "Patient" p
                      INNER JOIN "InitialCareAssessment" ica ON ica."PatientID_FK" = p."PatientID" AND (ica."Status" = 'Active' OR ica."Status" = 'Submitted')
                      INNER JOIN "Disease" d ON d."DiseaseName" = 'Risk for fall'
                      LEFT JOIN "DiseaseSubInfo" dsi ON d."DiseaseID" = dsi."DiseaseID_FK"
                      INNER JOIN "SystemForDisease" sfd ON d."SystemID_FK" = sfd."SystemID"
                      AND sfd."System" = 'General Nursing Diagnoses'
                      WHERE ica."MobilityStatus" IS NOT NULL AND ica."MobilityStatus" <> 'Independent'

                      UNION

                      -- 12. Nutritional Imbalance Nursing Diagnosis activated when "Underweight" is indicated
                      -- (vitalsign, detail value)
                      SELECT p."PatientID", p."Lastname", p."Firstname", ica."InitialCareAssessmentID", d."DiseaseID", d."DiseaseName", d."SystemID_FK", sfd."System", ica."Status", ica."IsDeleted", dsi."DiseaseSubInfoID", dsi."DiseaseSubInfo"
                      FROM "Patient" p
                      INNER JOIN "InitialCareAssessment" ica ON ica."PatientID_FK" = p."PatientID" AND (ica."Status" = 'Active' OR ica."Status" = 'Submitted')
                      INNER JOIN "SystemForDisease" sfd ON sfd."System" = 'General Nursing Diagnoses'
                      INNER JOIN "Disease" d ON d."SystemID_FK" = sfd."SystemID" AND d."DiseaseName" = 'Nutritional imbalance'
                      LEFT JOIN "DiseaseSubInfo" dsi ON d."DiseaseID" = dsi."DiseaseID_FK"
                      WHERE ica."NutritionalImbalance" IS TRUE

                      UNION

                      -- 13. If NGT Is selected, NGT component pops out and NGT Care Plan is activated
                      -- Fluid Restriction (EnteralFeeding--(NGT), IsFlsluidRestriction)
                      SELECT p."PatientID", p."Lastname", p."Firstname", ica."InitialCareAssessmentID", d."DiseaseID", d."DiseaseName", d."SystemID_FK", sfd."System", ica."Status", ica."IsDeleted", dsi."DiseaseSubInfoID", dsi."DiseaseSubInfo"
                      FROM "Patient" p
                      INNER JOIN "InitialCareAssessment" ica ON ica."PatientID_FK" = p."PatientID" AND (ica."Status" = 'Active' OR ica."Status" = 'Submitted')
                      INNER JOIN "PatientNutrition" pn ON pn."PatientNutritionID" = ica."PatientNutritionID_FK"
                      AND pn."Diet" = 'Enteral feeding' AND pn."EatingAndSwallowingTypeOfTubeFeeding" = 'NGT'
                      INNER JOIN "SystemForDisease" sfd ON sfd."System" = 'NGT Care'
                      INNER JOIN "Disease" d ON d."SystemID_FK" = sfd."SystemID"
                      LEFT JOIN "DiseaseSubInfo" dsi ON d."DiseaseID" = dsi."DiseaseID_FK"

                      UNION

                      -- 14. If No selected, Nursing Diagnosis of Urinary retention is activated
                      SELECT p."PatientID", p."Lastname", p."Firstname", ica."InitialCareAssessmentID", d."DiseaseID", d."DiseaseName", d."SystemID_FK", sfd."System", ica."Status", ica."IsDeleted", dsi."DiseaseSubInfoID", dsi."DiseaseSubInfo"
                      FROM "Patient" p
                      INNER JOIN "InitialCareAssessment" ica ON ica."PatientID_FK" = p."PatientID" AND (ica."Status" = 'Active' OR ica."Status" = 'Submitted')
                      INNER JOIN "Disease" d ON d."DiseaseName" = 'Urinary retention'
                      LEFT JOIN "DiseaseSubInfo" dsi ON d."DiseaseID" = dsi."DiseaseID_FK"
                      INNER JOIN "SystemForDisease" sfd ON d."SystemID_FK" = sfd."SystemID"
                      AND sfd."System" = 'General Nursing Diagnoses'
                      WHERE ica."AblePassUrine" IS FALSE

                      UNION

                      --15 . If Yes selected, state On Diapers/ On Urine Catheter; Nursing Diagnosis of Urinary incontinence is activated
                      --(InitialCareAssessment, Incontinence)
                      SELECT p."PatientID", p."Lastname", p."Firstname", ica."InitialCareAssessmentID", d."DiseaseID", d."DiseaseName", d."SystemID_FK", sfd."System", ica."Status", ica."IsDeleted", dsi."DiseaseSubInfoID", dsi."DiseaseSubInfo"
                      FROM "Patient" p
                      INNER JOIN "InitialCareAssessment" ica
                          ON ica."PatientID_FK" = p."PatientID"
                          AND (ica."Status" = 'Active' OR ica."Status" = 'Submitted')
                      INNER JOIN "Disease" d
                          ON d."DiseaseName" = 'Urinary incontinence'
                      LEFT JOIN "DiseaseSubInfo" dsi
                          ON d."DiseaseID" = dsi."DiseaseID_FK"
                      INNER JOIN "SystemForDisease" sfd
                          ON d."SystemID_FK" = sfd."SystemID"
                          AND sfd."System" = 'General Nursing Diagnoses'
                      WHERE ica."Incontinence" IS TRUE

                      UNION

                      SELECT p."PatientID", p."Lastname", p."Firstname", ica."InitialCareAssessmentID", d."DiseaseID", d."DiseaseName", d."SystemID_FK", sfd."System", ica."Status", ica."IsDeleted", dsi."DiseaseSubInfoID", dsi."DiseaseSubInfo"
                      FROM "Patient" p
                      INNER JOIN "InitialCareAssessment" ica
                          ON ica."PatientID_FK" = p."PatientID"
                          AND (ica."Status" = 'Active' OR ica."Status" = 'Submitted')
                      INNER JOIN "SystemForDisease" sfd
                          ON sfd."System" = 'Urine Catheter Care'
                      INNER JOIN "Disease" d
                          ON d."SystemID_FK" = sfd."SystemID"
                      LEFT JOIN "DiseaseSubInfo" dsi
                          ON d."DiseaseID" = dsi."DiseaseID_FK"
                      WHERE ica."Incontinence" IS TRUE
                          AND ica."IncontinenceType" = 'Urine Catheter'

                      UNION
                      --16 .If More than 2 days selected, Nursing Diagnosis of Constipation is activated
                      --( InitialCareAssessment, [BowelHabitsTimes])
                      SELECT p."PatientID", p."Lastname", p."Firstname", ica."InitialCareAssessmentID", d."DiseaseID", d."DiseaseName", d."SystemID_FK", sfd."System", ica."Status", ica."IsDeleted", dsi."DiseaseSubInfoID", dsi."DiseaseSubInfo"
                      FROM "Patient" p
                      INNER JOIN "InitialCareAssessment" ica
                          ON ica."PatientID_FK" = p."PatientID"
                          AND (ica."Status" = 'Active' OR ica."Status" = 'Submitted')
                      INNER JOIN "Disease" d
                          ON d."DiseaseName" = 'Constipation'
                      LEFT JOIN "DiseaseSubInfo" dsi
                          ON d."DiseaseID" = dsi."DiseaseID_FK"
                      INNER JOIN "SystemForDisease" sfd
                          ON d."SystemID_FK" = sfd."SystemID"
                          AND sfd."System" = 'General Nursing Diagnoses'
                      WHERE CAST(ica."BowelHabitsDays" AS NUMERIC) > 2;

                CREATE OR REPLACE VIEW "vw_CarePlanSetup" AS
                SELECT * FROM "vw_DiseaseCarePlanSetup"
                UNION
                SELECT * FROM "vw_MedicalHistoryCarePlanSetup"
                UNION
                SELECT * FROM "vw_AmtCarePlanSetup"
                UNION
                SELECT * FROM "vw_BradenScaleCarePlanSetup"
                UNION
                SELECT * FROM "vw_OralCarePlanSetup"
                UNION
                SELECT * FROM "vw_RafCarePlanSetup"
                UNION
                SELECT * FROM "vw_NursingDiagnosesCarePlanSetup";
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                DROP VIEW IF EXISTS "vw_DiseaseCarePlanSetup";
                DROP VIEW IF EXISTS "vw_MedicalHistoryCarePlanSetup";
                DROP VIEW IF EXISTS "vw_AmtCarePlanSetup";
                DROP VIEW IF EXISTS "vw_BradenScaleCarePlanSetup";
                DROP VIEW IF EXISTS "vw_OralCarePlanSetup";
                DROP VIEW IF EXISTS "vw_RafCarePlanSetup";
                DROP VIEW IF EXISTS "vw_NursingDiagnosesCarePlanSetup";
                DROP VIEW IF EXISTS "vw_CarePlanSetup";
                """);
        }
    }
}
