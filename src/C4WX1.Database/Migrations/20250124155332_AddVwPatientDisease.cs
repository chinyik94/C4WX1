using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4WX1.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddVwPatientDisease : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE OR REPLACE VIEW "vw_PatientDisease" AS
                -- PatientReferral PrimaryClinicianID_FK
                SELECT 
                  p."PatientID",
                  p."Lastname",
                  p."Firstname",
                  ica."InitialCareAssessmentID", 
                  d."DiseaseID",
                  d."DiseaseName",
                  d."SystemID_FK",
                  sfd."System",
                  ica."Status",
                  ica."IsDeleted",
                  dsi."DiseaseSubInfoID",
                  dsi."DiseaseSubInfo" 
                FROM "Patient" p
                INNER JOIN "InitialCareAssessment" ica ON ica."PatientID_FK" = p."PatientID" 
                  AND (ica."Status" = 'Active' OR ica."Status" = 'Submitted')
                INNER JOIN "PatientReferral" pr ON ica."PatientReferralID_FK" = pr."PatientReferralID"
                INNER JOIN "PatientClinician" pc ON pr."PrimaryClinicianID_FK" = pc."PatientClinicianID"
                INNER JOIN "Disease" d ON d."DiseaseID" = pc."DiseaseID_FK" 
                  AND d."SystemID_FK" NOT IN (SELECT "SystemID" FROM "SystemForDisease" WHERE "System" = 'Family History')
                LEFT JOIN "DiseaseSubInfo" dsi ON d."DiseaseID" = dsi."DiseaseID_FK" 
                  AND dsi."DiseaseSubInfoID" = pc."DiseaseSubInfoID_FK"
                LEFT JOIN "SystemForDisease" sfd ON d."SystemID_FK" = sfd."SystemID"
                
                -- PatientReferral SecondaryClinicianID_FK
                UNION
                SELECT 
                  p."PatientID",
                  p."Lastname",
                  p."Firstname",
                  ica."InitialCareAssessmentID", 
                  d."DiseaseID",
                  d."DiseaseName",
                  d."SystemID_FK",
                  sfd."System",
                  ica."Status",
                  ica."IsDeleted",
                  dsi."DiseaseSubInfoID",
                  dsi."DiseaseSubInfo" 
                FROM "Patient" p
                INNER JOIN "InitialCareAssessment" ica ON ica."PatientID_FK" = p."PatientID" 
                  AND (ica."Status" = 'Active' OR ica."Status" = 'Submitted')
                INNER JOIN "PatientReferral" pr ON ica."PatientReferralID_FK" = pr."PatientReferralID"
                INNER JOIN "PatientClinician" pc ON pr."SecondaryClinicianID_FK" = pc."PatientClinicianID"
                INNER JOIN "Disease" d ON d."DiseaseID" = pc."DiseaseID_FK" 
                  AND d."SystemID_FK" NOT IN (SELECT "SystemID" FROM "SystemForDisease" WHERE "System" = 'Family History')
                LEFT JOIN "DiseaseSubInfo" dsi ON d."DiseaseID" = dsi."DiseaseID_FK" 
                  AND dsi."DiseaseSubInfoID" = pc."DiseaseSubInfoID_FK"
                LEFT JOIN "SystemForDisease" sfd ON d."SystemID_FK" = sfd."SystemID"
                
                -- Medical History
                UNION
                SELECT 
                  p."PatientID",
                  p."Lastname",
                  p."Firstname",
                  ica."InitialCareAssessmentID", 
                  d."DiseaseID",
                  d."DiseaseName",
                  d."SystemID_FK",
                  sfd."System",
                  ica."Status",
                  ica."IsDeleted",
                  dsi."DiseaseSubInfoID",
                  dsi."DiseaseSubInfo" 
                FROM "Patient" p
                INNER JOIN "InitialCareAssessment" ica ON ica."PatientID_FK" = p."PatientID" 
                  AND (ica."Status" = 'Active' OR ica."Status" = 'Submitted')
                INNER JOIN "PatientMedicalHistory" pmh ON ica."InitialCareAssessmentID" = pmh."InitialCareAssessmentID_FK"
                INNER JOIN "PatientClinician" pc ON pmh."ClinicianID_FK" = pc."PatientClinicianID"
                INNER JOIN "Disease" d ON d."DiseaseID" = pc."DiseaseID_FK" 
                  AND d."SystemID_FK" NOT IN (SELECT "SystemID" FROM "SystemForDisease" WHERE "System" = 'Family History')
                LEFT JOIN "DiseaseSubInfo" dsi ON d."DiseaseID" = dsi."DiseaseID_FK" 
                  AND dsi."DiseaseSubInfoID" = pc."DiseaseSubInfoID_FK"
                LEFT JOIN "SystemForDisease" sfd ON d."SystemID_FK" = sfd."SystemID"
                
                -- Patient AMT
                UNION
                SELECT 
                  p."PatientID",
                  p."Lastname",
                  p."Firstname",
                  ica."InitialCareAssessmentID", 
                  d."DiseaseID",
                  d."DiseaseName",
                  d."SystemID_FK",
                  sfd."System",
                  ica."Status",
                  ica."IsDeleted",
                  dsi."DiseaseSubInfoID",
                  dsi."DiseaseSubInfo" 
                FROM "Patient" p
                INNER JOIN "InitialCareAssessment" ica ON ica."PatientID_FK" = p."PatientID" 
                  AND (ica."Status" = 'Active' OR ica."Status" = 'Submitted')
                INNER JOIN "PatientAMT" pamt ON ica."InitialCareAssessmentID" = pamt."InitialCareAssessmentID_FK" 
                  AND pamt."Score" >= 7
                INNER JOIN "Disease" d ON d."DiseaseID" = 100000 -- Cognitive Impairment
                LEFT JOIN "DiseaseSubInfo" dsi ON d."DiseaseID" = dsi."DiseaseID_FK"
                LEFT JOIN "SystemForDisease" sfd ON d."SystemID_FK" = sfd."SystemID"
                
                -- Braden Scale
                UNION
                SELECT 
                  p."PatientID",
                  p."Lastname",
                  p."Firstname",
                  ica."InitialCareAssessmentID", 
                  d."DiseaseID",
                  d."DiseaseName",
                  d."SystemID_FK",
                  sfd."System",
                  ica."Status",
                  ica."IsDeleted",
                  dsi."DiseaseSubInfoID",
                  dsi."DiseaseSubInfo" 
                FROM "Patient" p
                INNER JOIN "InitialCareAssessment" ica ON ica."PatientID_FK" = p."PatientID" 
                  AND (ica."Status" = 'Active' OR ica."Status" = 'Submitted')
                  AND (ica."WoundAssessmentScore1" + ica."WoundAssessmentScore2" + ica."WoundAssessmentScore3" + 
                       ica."WoundAssessmentScore4" + ica."WoundAssessmentScore5" + ica."WoundAssessmentScore6") < 19
                INNER JOIN "Disease" d ON d."DiseaseID" = 100001 -- Impaired Skin Integrity
                LEFT JOIN "DiseaseSubInfo" dsi ON d."DiseaseID" = dsi."DiseaseID_FK"
                LEFT JOIN "SystemForDisease" sfd ON d."SystemID_FK" = sfd."SystemID"
                
                -- Oral (various conditions)
                UNION
                SELECT 
                  p."PatientID",
                  p."Lastname",
                  p."Firstname",
                  ica."InitialCareAssessmentID", 
                  d."DiseaseID",
                  d."DiseaseName",
                  d."SystemID_FK",
                  sfd."System",
                  ica."Status",
                  ica."IsDeleted",
                  dsi."DiseaseSubInfoID",
                  dsi."DiseaseSubInfo" 
                FROM "Patient" p
                INNER JOIN "InitialCareAssessment" ica ON ica."PatientID_FK" = p."PatientID" 
                  AND (ica."Status" = 'Active' OR ica."Status" = 'Submitted')
                  AND (ica."OralCavityAssessmentScore1" + ica."OralCavityAssessmentScore2" + ica."OralCavityAssessmentScore3" + 
                       ica."OralCavityAssessmentScore4" + ica."OralCavityAssessmentScore5" + ica."OralCavityAssessmentScore6") BETWEEN 6 AND 11
                INNER JOIN "Disease" d ON d."DiseaseID" = 100002 -- Mild dysfunction of the oral cavity
                LEFT JOIN "DiseaseSubInfo" dsi ON d."DiseaseID" = dsi."DiseaseID_FK"
                LEFT JOIN "SystemForDisease" sfd ON d."SystemID_FK" = sfd."SystemID"
                
                -- Oral (Moderate dysfunction)
                UNION
                SELECT 
                  p."PatientID",
                  p."Lastname",
                  p."Firstname",
                  ica."InitialCareAssessmentID", 
                  d."DiseaseID",
                  d."DiseaseName",
                  d."SystemID_FK",
                  sfd."System",
                  ica."Status",
                  ica."IsDeleted",
                  dsi."DiseaseSubInfoID",
                  dsi."DiseaseSubInfo" 
                FROM "Patient" p
                INNER JOIN "InitialCareAssessment" ica ON ica."PatientID_FK" = p."PatientID" 
                  AND (ica."Status" = 'Active' OR ica."Status" = 'Submitted')
                  AND (ica."OralCavityAssessmentScore1" + ica."OralCavityAssessmentScore2" + ica."OralCavityAssessmentScore3" + 
                       ica."OralCavityAssessmentScore4" + ica."OralCavityAssessmentScore5" + ica."OralCavityAssessmentScore6") BETWEEN 12 AND 17
                INNER JOIN "Disease" d ON d."DiseaseID" = 100003 -- Moderate dysfunction of the oral cavity
                LEFT JOIN "DiseaseSubInfo" dsi ON d."DiseaseID" = dsi."DiseaseID_FK"
                LEFT JOIN "SystemForDisease" sfd ON d."SystemID_FK" = sfd."SystemID"
                
                -- Severe dysfunction of the oral cavity
                UNION
                SELECT 
                  p."PatientID",
                  p."Lastname",
                  p."Firstname",
                  ica."InitialCareAssessmentID", 
                  d."DiseaseID",
                  d."DiseaseName",
                  d."SystemID_FK",
                  sfd."System",
                  ica."Status",
                  ica."IsDeleted",
                  dsi."DiseaseSubInfoID",
                  dsi."DiseaseSubInfo" 
                FROM "Patient" p
                INNER JOIN "InitialCareAssessment" ica ON ica."PatientID_FK" = p."PatientID" 
                  AND (ica."Status" = 'Active' OR ica."Status" = 'Submitted')
                  AND (ica."OralCavityAssessmentScore1" + ica."OralCavityAssessmentScore2" + ica."OralCavityAssessmentScore3" + 
                       ica."OralCavityAssessmentScore4" + ica."OralCavityAssessmentScore5" + ica."OralCavityAssessmentScore6") BETWEEN 18 AND 24
                INNER JOIN "Disease" d ON d."DiseaseID" = 100004 -- Severe dysfunction of the oral cavity
                LEFT JOIN "DiseaseSubInfo" dsi ON d."DiseaseID" = dsi."DiseaseID_FK"
                LEFT JOIN "SystemForDisease" sfd ON d."SystemID_FK" = sfd."SystemID";
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                DROP VIEW IF EXISTS "vw_PatientDisease";
                """);
        }
    }
}
