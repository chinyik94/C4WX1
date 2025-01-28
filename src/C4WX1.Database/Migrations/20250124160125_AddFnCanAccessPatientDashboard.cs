using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4WX1.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddFnCanAccessPatientDashboard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE OR REPLACE FUNCTION "fn_CanAccessPatientDashboard"(
                    user_id INTEGER,
                    patient_id INTEGER,
                    facility_id INTEGER
                )
                RETURNS BOOLEAN AS $$
                DECLARE
                    facility_allowed BOOLEAN := FALSE;
                BEGIN
                    -- Check Access Patient By Facility
                    IF EXISTS (
                        SELECT 1
                        FROM "UserCategoryFacility" ucf
                        INNER JOIN "UserType" ut ON ucf."UserCategoryID_FK" = ut."UserCategoryID_FK"
                        INNER JOIN "UserUserType" uut ON uut."UserTypeID_FK" = ut."UserTypeID"
                        INNER JOIN "PatientFacility" pf ON ucf."FacilityID_FK" = pf."FacilityID_FK"
                        WHERE uut."UserID_FK" = user_id
                          AND pf."PatientID_FK" = patient_id
                          AND ucf."FacilityID_FK" = facility_id
                    ) THEN
                        facility_allowed := TRUE;
                    END IF;
                
                    -- Check additional access conditions
                    IF user_id IS NOT NULL AND patient_id IS NOT NULL THEN
                        -- Check in PatientClinician
                        IF EXISTS (
                            SELECT 1
                            FROM "PatientClinician"
                            WHERE "IsDeleted" = FALSE
                              AND "UserID_FK" = user_id
                              AND "PatientID_FK" = patient_id
                              AND facility_allowed = TRUE
                        ) THEN
                            RETURN TRUE;
                
                        -- Check in Patient table
                        ELSIF EXISTS (
                            SELECT 1
                            FROM "Patient"
                            WHERE "PatientID" = patient_id
                              AND ("CreatedBy_FK" = user_id OR "ModifiedBy_FK" = user_id)
                              AND facility_allowed = TRUE
                        ) THEN
                            RETURN TRUE;
                
                        -- Check in Users and related tables
                        ELSIF EXISTS (
                            SELECT 1
                            FROM "Users" u
                            INNER JOIN "UserUserType" uut ON u."UserId" = uut."UserID_FK"
                            INNER JOIN "UserType" ut ON uut."UserTypeID_FK" = ut."UserTypeID"
                            INNER JOIN "UserCategoryRole" ucr ON ucr."UserCategoryID_FK" = ut."UserCategoryID_FK"
                            LEFT JOIN "Role" r ON r."RoleId" = ucr."RoleID_FK" AND r."RoleDescription" = 'Patients Assignment'
                            WHERE u."UserId" = user_id
                              AND (
                                  ut."UserCategoryID_FK" = 1 OR 
                                  u."PatientID_FK" = patient_id OR 
                                  r."RoleId" > 0
                              )
                              AND u."Status" = 'Active'
                              AND facility_allowed = TRUE
                        ) THEN
                            RETURN TRUE;
                
                        -- Check access for all patients
                        ELSIF EXISTS (
                            SELECT 1
                            FROM "UserUserType" uut
                            INNER JOIN "UserType" ut ON uut."UserTypeID_FK" = ut."UserTypeID"
                            INNER JOIN "UserCategoryRole" ucr ON ut."UserCategoryID_FK" = ucr."UserCategoryID_FK"
                              AND ucr."RoleID_FK" = 35
                              AND POSITION('Z' IN ucr."Role") > 0
                            WHERE uut."UserID_FK" = user_id
                              AND facility_allowed = TRUE
                        ) THEN
                            RETURN TRUE;
                
                        -- General facility access
                        ELSIF facility_allowed = TRUE THEN
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
                DROP FUNCTION IF EXISTS "fn_CanAccessPatientDashboard";
                """);
        }
    }
}
