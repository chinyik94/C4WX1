using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4WX1.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddVwUserRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE OR REPLACE VIEW "vw_UserRoles" AS
                SELECT 
                      "u"."UserId", 
                      "u"."Email", 
                      "u"."Firstname", 
                      "u"."Lastname", 
                      "ut"."UserTypeID", 
                      "ut"."UserType", 
                      "ucr"."UserCategoryID_FK", 
                      "ucr"."RoleID_FK", 
                      "ucr"."Role" AS "UserRole", 
                      "uc"."UserCategory", 
                      "r"."RoleDescription", 
                      "u"."Status", 
                      "uc"."EnableGeoFencing"
                FROM "Users" "u"
                LEFT JOIN "UserUserType" "uut" ON "uut"."UserID_FK" = "u"."UserId"
                LEFT JOIN "UserType" "ut" ON "ut"."UserTypeID" = "uut"."UserTypeID_FK" AND "ut"."IsDeleted" IS FALSE
                LEFT JOIN "UserCategoryRole" "ucr" ON "ucr"."UserCategoryID_FK" = "ut"."UserCategoryID_FK"
                LEFT JOIN "UserCategory" "uc" ON "uc"."UserCategoryID" = "ucr"."UserCategoryID_FK" AND "uc"."IsDeleted" IS FALSE
                LEFT JOIN "Role" "r" ON "r"."RoleId" = "ucr"."RoleID_FK" AND "r"."Active" IS TRUE
                WHERE "u"."IsDeleted" IS FALSE;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                DROP VIEW IF EXISTS "vw_UserRoles";
                """);
        }
    }
}
