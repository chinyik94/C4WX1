using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4WX1.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddVwPatientWoundImageDownload : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE VIEW "vw_PatientWoundImageDownload" AS
                SELECT 
                  "p"."Firstname" || '_' || "p"."Lastname" || '_' || "pw"."LocationOfWound" || '_' || "pw"."Site" || '_' || TO_CHAR("pwv"."VisitDate", 'YYYYMMDD') || '_' || TO_CHAR("pwv"."PatientWoundVisitID", 'FM999999999') AS "NewImageName",
                  "p"."PatientID",
                  "p"."Firstname",
                  "p"."Lastname",
                  "pw"."PatientWoundID",
                  "pw"."LocationOfWound",
                  "pw"."Site",
                  "pwv"."PatientWoundVisitID",
                  TO_CHAR("pwv"."VisitDate", 'YYYYMMDD') AS "ImageDate",
                  "pwv"."VisitDate",
                  "pwv"."ImageUpload"
                FROM "PatientWound" "pw"
                INNER JOIN "Patient" "p" ON "p"."PatientID" = "pw"."PatientID_FK"
                INNER JOIN "PatientWoundVisit" "pwv" ON "pw"."PatientWoundID" = "pwv"."PatientWoundID_FK"
                WHERE "pw"."PatientID_FK" IS NOT NULL;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                DROP VIEW IF EXISTS "vw_PatientWoundImageDownload";
                """);
        }
    }
}
