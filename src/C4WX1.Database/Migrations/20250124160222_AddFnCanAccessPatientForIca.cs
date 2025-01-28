using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4WX1.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddFnCanAccessPatientForIca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE OR REPLACE FUNCTION "fn_CanAccessPatientForIca"(
                    user_id INTEGER,
                    initial_care_assessment_id INTEGER
                )
                RETURNS BOOLEAN
                LANGUAGE plpgsql
                AS $$
                BEGIN
                    -- Check if user_id and initial_care_assessment_id are not null
                    IF user_id IS NOT NULL AND initial_care_assessment_id IS NOT NULL THEN
                        -- Check if the user is associated with the patient as a clinician
                        IF EXISTS(
                            SELECT 1 
                            FROM "PatientClinician"
                            WHERE "IsDeleted" = FALSE 
                              AND "UserID_FK" = user_id 
                              AND "InitialCareAssessmentID_FK" = initial_care_assessment_id
                        ) THEN
                            RETURN TRUE;
                        END IF;
                
                        -- Check if the user created or modified the patient associated with the assessment
                        IF EXISTS(
                            SELECT 1 
                            FROM "Patient"
                            WHERE "PatientID" = (
                                SELECT "PatientID_FK" 
                                FROM "InitialCareAssessment" 
                                WHERE "InitialCareAssessmentID" = initial_care_assessment_id
                            ) 
                              AND ("CreatedBy_FK" = user_id OR "ModifiedBy_FK" = user_id)
                        ) THEN
                            RETURN TRUE;
                        END IF;
                
                        -- Check if the user has the required user type category
                        IF EXISTS(
                            SELECT 1 
                            FROM "Users" u
                            INNER JOIN "UserUserType" uut ON u."UserId" = uut."UserID_FK"
                            INNER JOIN "UserType" ut ON uut."UserTypeID_FK" = ut."UserTypeID"
                            WHERE ut."UserCategoryID_FK" = 1 
                              AND u."UserId" = user_id
                        ) THEN
                            RETURN TRUE;
                        END IF;
                    END IF;
                
                    -- Default return false
                    RETURN FALSE;
                END;
                $$;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                DROP FUNCTION IF EXISTS "fn_CanAccessPatientForIca";
                """);
        }
    }
}
