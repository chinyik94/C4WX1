using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4WX1.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddVwPatientWound : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE OR REPLACE VIEW "vw_PatientWound" AS
                SELECT 
                  "pw"."PatientID_FK" AS "PatientID",
                  "pw"."PatientWoundID",
                  "pwv"."PatientWoundVisitID",
                  "pw"."LocationOfWound", 
                  "pw"."Site",
                  COALESCE(NULLIF("p"."DisplayName", ''), "p"."Firstname" || ' ' || "p"."Lastname") AS "patientName", 
                  "p"."Status", 
                  "createdUser"."Firstname" || ' ' || "createdUser"."Lastname" AS "createdBy", 
                  "modifiedUser"."Firstname" || ' ' || "modifiedUser"."Lastname" AS "modifiedBy", 
                  "pwv"."CreatedBy_FK",  
                  "pwv"."ModifiedBy_FK",
                  (SELECT MAX("pwv1"."VisitDate")::DATE 
                   FROM "PatientWoundVisit" "pwv1" 
                   WHERE "pwv1"."PatientWoundID_FK" = "pw"."PatientWoundID") AS "LastVisitDate",
                  "pwv"."NextReviewDate",
                  "pwv"."NextTreatmentDate",
                  "pw"."Category",
                  "pw"."Stage"
                FROM "Patient" "p"
                  INNER JOIN "PatientWound" "pw" ON "p"."PatientID" = "pw"."PatientID_FK" 
                    AND "pw"."IsDeleted" IS FALSE
                    AND "pw"."CareReportID_FK" IS NULL 
                    AND "pw"."InitialCareAssessmentID_FK" IS NULL 
                    AND "pw"."IsDeleted" IS FALSE
                  INNER JOIN "PatientWoundVisit" "pwv" ON "pw"."PatientWoundID" = "pwv"."PatientWoundID_FK" 
                    AND "pwv"."IsDeleted" IS FALSE
                  INNER JOIN "Users" "createdUser" ON "createdUser"."UserId" = "pwv"."CreatedBy_FK"
                  LEFT JOIN "Users" "modifiedUser" ON "modifiedUser"."UserId" = "pwv"."ModifiedBy_FK"
                WHERE "pwv"."VisitDate" = (SELECT MAX("PatientWoundVisit"."VisitDate") 
                                           FROM "PatientWoundVisit" 
                                           WHERE "PatientWoundVisit"."PatientWoundID_FK" = "pw"."PatientWoundID")
                GROUP BY 
                  "pw"."PatientID_FK", 
                  "pw"."PatientWoundID", 
                  "pwv"."PatientWoundVisitID", 
                  "pw"."LocationOfWound", 
                  "pw"."Site", 
                  "p"."DisplayName", 
                  "p"."Firstname", 
                  "p"."Status", 
                  "p"."Lastname", 
                  "createdUser"."Firstname", 
                  "createdUser"."Lastname", 
                  "modifiedUser"."Firstname", 
                  "modifiedUser"."Lastname", 
                  "pwv"."CreatedBy_FK", 
                  "pwv"."ModifiedBy_FK", 
                  "pwv"."NextReviewDate", 
                  "pwv"."NextTreatmentDate", 
                  "pw"."Category", 
                  "pw"."Stage";
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                DROP VIEW IF EXISTS "vw_PatientWound";
                """);
        }
    }
}
