using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4WX1.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddFnCanAccessUserCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE OR REPLACE FUNCTION "fn_CanAccessUserCategory"(
                    user_id INTEGER,
                    access_user_category_id INTEGER,
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
                        WHERE uut."UserID_FK" = user_id
                          AND ucf."FacilityID_FK" = facility_id
                          AND ucpc."ChildUserCategoryID_FK" = access_user_category_id
                    ) THEN
                        RETURN TRUE;
                    END IF;
                
                    -- Uncomment this block to allow super admin access to all user categories
                    -- IF EXISTS(
                    --     SELECT 1
                    --     FROM "UserCategory"
                    --     WHERE "IsDeleted" = FALSE
                    --       AND access_user_category_id = "UserCategoryID"
                    --       AND user_id = 1 -- SuperAdmin UserID
                    -- ) THEN
                    --     RETURN TRUE;
                    -- END IF;
                
                    RETURN FALSE;
                END;
                $$;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                DROP FUNCTION IF EXISTS "fn_CanAccessUserCategory";
                """);
        }
    }
}
