using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4WX1.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddVwPatientLatestVitalSigns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE OR REPLACE VIEW "vw_PatientLatestVitalSigns" AS
                SELECT 
                  "vs"."patientId",
                  "vs"."createdDate" AS "VitalSignDate",
                  "vsd"."id" AS "VitalSignDetailId",
                  "vsd"."vitalSignTypeId",
                  "vst"."name" AS "VitalSignTypeName",
                  "vsd"."detailValue" AS "Value",
                  "t"."minValue" AS "ThresholdMinValue",
                  "t"."maxValue" AS "ThresholdMaxValue",
                  "t"."ews_min_1",
                  "t"."ews_max_1",
                  "t"."ews_min_2",
                  "t"."ews_max_2",
                  "t"."ews_min_3",
                  "t"."ews_max_3",
                  "t"."ews_min_4",
                  "t"."ews_max_4",
                  "t"."ews_min_5",
                  "t"."ews_max_5",
                  "t"."ews_min_6",
                  "t"."ews_max_6",
                  "t"."ews_min_7",
                  "t"."ews_max_7",
                  ROW_NUMBER() OVER (PARTITION BY "vs"."patientId", "vst"."id" ORDER BY "vs"."createdDate" DESC, "vsd"."id" DESC) AS "Index"
                FROM "VitalSigns" "vs"
                  INNER JOIN "VitalSignDetails" "vsd" ON "vs"."id" = "vsd"."vitalSignId" AND "vsd"."IsDeleted" IS FALSE
                  INNER JOIN "VitalSignTypes" "vst" ON "vsd"."vitalSignTypeId" = "vst"."id"
                  LEFT JOIN "VitalSignRelationships" "vsr" ON "vsr"."vitalSignTypeId" = "vst"."id" AND "vsr"."patientId" = "vs"."patientId"
                  LEFT JOIN "Thresholds" "t" ON "t"."id" = "vsr"."thresholdId" AND "t"."isDeleted" IS FALSE
                WHERE "vs"."icaId" = 0 AND "vs"."isDeleted" IS FALSE;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                DROP VIEW IF EXISTS "vw_PatientLatestVitalSigns";
                """);
        }
    }
}
