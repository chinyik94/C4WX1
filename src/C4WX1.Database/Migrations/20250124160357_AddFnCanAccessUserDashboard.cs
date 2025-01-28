using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4WX1.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddFnCanAccessUserDashboard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE OR REPLACE FUNCTION "fn_CanAccessUserDashboard"(
                    user_id INTEGER,
                    access_user_id INTEGER,
                    facility_id INTEGER
                )
                RETURNS BOOLEAN
                LANGUAGE plpgsql
                AS $$
                BEGIN
                    -- Check Access User By Facility
                    IF EXISTS(
                        SELECT 1
                        FROM "UserCategoryFacility" ucf
                        INNER JOIN "UserType" ut ON ucf."UserCategoryID_FK" = ut."UserCategoryID_FK"
                        INNER JOIN "UserUserType" uut ON uut."UserTypeID_FK" = ut."UserTypeID"
                        INNER JOIN "UserCategoryParentChild" ucpc ON ucpc."ParentUserCategoryID_FK" = ut."UserCategoryID_FK"
                        INNER JOIN "UserCategoryFacility" ucf2 ON ucpc."ChildUserCategoryID_FK" = ucf2."UserCategoryID_FK"
                        INNER JOIN "UserType" ut2 ON ucf2."UserCategoryID_FK" = ut2."UserCategoryID_FK"
                        INNER JOIN "UserUserType" uut2 ON uut2."UserTypeID_FK" = ut2."UserTypeID" 
                            AND uut2."UserID_FK" = access_user_id
                        WHERE uut."UserID_FK" = user_id 
                          AND ucf."FacilityID_FK" = facility_id 
                          AND ucf2."FacilityID_FK" = facility_id
                    ) THEN
                        RETURN TRUE;
                    END IF;
                
                    RETURN FALSE;
                END;
                $$;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                DROP FUNCTION IF EXISTS "fn_CanAccessUserDashboard";
                """);
        }
    }
}
