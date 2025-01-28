using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4WX1.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddVwDoctors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE OR REPLACE VIEW "vw_Doctors" AS
                SELECT u."UserId" AS "InternalId", NULL AS "ExternalId", u."Firstname" || ' ' || u."Lastname" AS "DoctorName"
                FROM "Users" u
                WHERE u."IsDeleted" IS FALSE 
                  AND u."Status" = 'Active' 
                  AND EXISTS (
                      SELECT 1
                      FROM "UserUserType" uut
                      INNER JOIN "UserType" ut ON uut."UserTypeID_FK" = ut."UserTypeID"
                      WHERE ut."IsDeleted" IS FALSE
                        AND uut."UserID_FK" = u."UserId"
                        AND ut."UserCategoryID_FK" IN (2, 4)
                  )
                UNION ALL
                SELECT NULL AS "InternalId", "ExternalDoctorID" AS "ExternalId", "Name" AS "DoctorName"
                FROM "ExternalDoctor"
                WHERE "IsDeleted" IS FALSE;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                DROP VIEW IF EXISTS "vw_Doctors";
                """);
        }
    }
}
