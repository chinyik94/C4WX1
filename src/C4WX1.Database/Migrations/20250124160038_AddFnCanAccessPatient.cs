using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4WX1.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddFnCanAccessPatient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE OR REPLACE FUNCTION "fn_CanAccessPatient"(
                    user_id INTEGER,
                    patient_id INTEGER
                )
                RETURNS BOOLEAN AS $$
                DECLARE
                    "FacilityAllowed" BOOLEAN := FALSE;
                BEGIN
                    -- Check Access Patient By Facility, same facility with user
                    IF EXISTS (
                        SELECT 1
                        FROM "UserCategoryFacility" ucf
                        INNER JOIN "UserType" ut ON ucf."UserCategoryID_FK" = ut."UserCategoryID_FK"
                        INNER JOIN "UserUserType" uut ON uut."UserTypeID_FK" = ut."UserTypeID"
                        INNER JOIN "PatientFacility" pf ON ucf."FacilityID_FK" = pf."FacilityID_FK"
                        WHERE uut."UserID_FK" = user_id
                          AND pf."PatientID_FK" = patient_id
                    ) THEN
                        "FacilityAllowed" := TRUE;
                    END IF;
                
                    -- Check additional access conditions
                    IF user_id IS NOT NULL AND patient_id IS NOT NULL THEN
                        -- Check in patientClinician
                        IF EXISTS (
                            SELECT 1
                            FROM "PatientClinician"
                            WHERE "IsDeleted" = FALSE
                              AND "UserID_FK" = user_id
                              AND "PatientID_FK" = patient_id
                              AND "FacilityAllowed" = TRUE
                        ) THEN
                            RETURN TRUE;
                        -- Check in patient table
                        ELSIF EXISTS (
                            SELECT 1
                            FROM "Patient"
                            WHERE "PatientID" = patient_id
                              AND ("CreatedBy_FK" = user_id OR "ModifiedBy_FK" = user_id)
                              AND "FacilityAllowed" = TRUE
                        ) THEN
                            RETURN TRUE;
                        -- Check in users and related tables
                        ELSIF EXISTS (
                            SELECT 1
                            FROM "Users" u
                            INNER JOIN "UserUserType" uut ON u."UserId" = uut."UserID_FK"
                            INNER JOIN "UserType" ut ON uut."UserTypeID_FK" = ut."UserTypeID"
                            INNER JOIN "UserCategoryRole" ucr ON ucr."UserCategoryID_FK" = ut."UserCategoryID_FK"
                            LEFT JOIN "Role" r ON r."RoleId" = ucr."RoleID_FK" AND r."RoleDescription" = 'Patients Assignment'
                            WHERE u."UserId" = user_id
                              AND (
                                ut."UserCategoryID_FK" = 1
                                OR u."PatientID_FK" = patient_id
                                OR r."RoleId" > 0
                              )
                              AND u."Status" = 'Active'
                              AND "FacilityAllowed" = TRUE
                        ) THEN
                            RETURN TRUE;
                        END IF;
                    END IF;
                
                    -- Default return
                    RETURN FALSE;
                END;
                $$ LANGUAGE plpgsql;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                DROP FUNCTION IF EXISTS "fn_CanAccessPatient";
                """);
        }
    }
}
