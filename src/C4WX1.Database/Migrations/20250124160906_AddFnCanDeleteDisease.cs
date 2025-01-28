using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4WX1.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddFnCanDeleteDisease : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE OR REPLACE FUNCTION "fn_CanDeleteDisease" (
                    id INTEGER
                )
                RETURNS BOOLEAN AS $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 
                        FROM "Patient" p 
                        INNER JOIN "PatientClinician" pc ON p."PatientID" = pc."PatientID_FK" 
                        WHERE NOT pc."IsDeleted" AND pc."DiseaseID_FK" = id
                    ) OR EXISTS (
                        SELECT 1 
                        FROM "Patient" p 
                        INNER JOIN "PatientFamilyHistory" pf ON p."PatientID" = pf."PatientID_FK" 
                        WHERE NOT pf."IsDeleted" AND pf."CreatedBy_FK" = id
                    ) OR EXISTS (
                        SELECT 1 
                        FROM "InitialCareAssessment" i 
                        INNER JOIN "PatientClinician" pc ON i."InitialCareAssessmentID" = pc."InitialCareAssessmentID_FK" 
                        WHERE NOT pc."IsDeleted" AND pc."DiseaseID_FK" = id
                    ) OR EXISTS (
                        SELECT 1 
                        FROM "InitialCareAssessment" i 
                        INNER JOIN "PatientFamilyHistory" pf ON i."InitialCareAssessmentID" = pf."InitialCareAssessmentID_FK" 
                        WHERE NOT pf."IsDeleted" AND pf."DiseaseID_FK" = id
                    ) THEN
                        RETURN FALSE;
                    END IF;
                
                    RETURN TRUE;
                END;
                $$ LANGUAGE plpgsql;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                DROP FUNCTION IF EXISTS "fn_CanDeleteDisease";
                """);
        }
    }
}
