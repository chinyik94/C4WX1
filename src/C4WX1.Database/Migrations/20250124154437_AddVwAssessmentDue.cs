using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4WX1.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddVwAssessmentDue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE VIEW "vw_AmtAssessmentDue" AS
                SELECT * FROM 
                (
                    SELECT vs."patientId", vs."source", vs."icaId", vs."createdDate", vs."createdBy", 
                           vs."updatedDate", vs."updatedBy", vst."name" AS "AssessmentName", 
                           vs."createdDate" + INTERVAL '6 months' AS "DueDate"
                    FROM "VitalSigns" vs
                    INNER JOIN "VitalSignDetails" vsd ON vsd."vitalSignId" = vs."id" AND vsd."IsDeleted" = FALSE
                    INNER JOIN "VitalSignTypes" vst ON vst."id" = vsd."vitalSignTypeId" AND vst."isDeleted" = FALSE
                    WHERE vsd."vitalSignTypeId" IN (12)
                    ORDER BY vs."createdDate" DESC
                    LIMIT 1
                );

                CREATE VIEW "vw_RafAssessmentDue" AS
                SELECT * FROM 
                (
                    SELECT vs."patientId", vs."source", vs."icaId", vs."createdDate", vs."createdBy", 
                           vs."updatedDate", vs."updatedBy", vst."name" AS "AssessmentName", 
                           vs."createdDate" + INTERVAL '6 months' AS "DueDate"
                    FROM "VitalSigns" vs
                    INNER JOIN "VitalSignDetails" vsd ON vsd."vitalSignId" = vs."id" AND vsd."IsDeleted" = FALSE
                    INNER JOIN "VitalSignTypes" vst ON vst."id" = vsd."vitalSignTypeId" AND vst."isDeleted" = FALSE
                    WHERE vsd."vitalSignTypeId" IN (13)
                    ORDER BY vs."createdDate" DESC
                    LIMIT 1
                );

                CREATE VIEW "vw_MbiAssessmentDue" AS
                SELECT * FROM 
                (
                    SELECT vs."patientId", vs."source", vs."icaId", vs."createdDate", vs."createdBy", 
                           vs."updatedDate", vs."updatedBy", vst."name" AS "AssessmentName", 
                           vs."createdDate" + INTERVAL '6 months' AS "DueDate"
                    FROM "VitalSigns" vs
                    INNER JOIN "VitalSignDetails" vsd ON vsd."vitalSignId" = vs."id" AND vsd."IsDeleted" = FALSE
                    INNER JOIN "VitalSignTypes" vst ON vst."id" = vsd."vitalSignTypeId" AND vst."isDeleted" = FALSE
                    WHERE vsd."vitalSignTypeId" IN (14)
                    ORDER BY vs."createdDate" DESC
                    LIMIT 1
                );

                CREATE VIEW "vw_MfsAssessmentDue" AS
                SELECT * FROM 
                (
                    SELECT vs."patientId", vs."source", vs."icaId", vs."createdDate", vs."createdBy", 
                           vs."updatedDate", vs."updatedBy", vst."name" AS "AssessmentName", 
                           vs."createdDate" + INTERVAL '6 months' AS "DueDate"
                    FROM "VitalSigns" vs
                    INNER JOIN "VitalSignDetails" vsd ON vsd."vitalSignId" = vs."id" AND vsd."IsDeleted" = FALSE
                    INNER JOIN "VitalSignTypes" vst ON vst."id" = vsd."vitalSignTypeId" AND vst."isDeleted" = FALSE
                    WHERE vsd."vitalSignTypeId" IN (15)
                    ORDER BY vs."createdDate" DESC
                    LIMIT 1
                );

                CREATE VIEW "vw_EbasDepAssessmentDue" AS
                SELECT * FROM 
                (
                    SELECT vs."patientId", vs."source", vs."icaId", vs."createdDate", vs."createdBy", 
                           vs."updatedDate", vs."updatedBy", vst."name" AS "AssessmentName", 
                           vs."createdDate" + INTERVAL '6 months' AS "DueDate"
                    FROM "VitalSigns" vs
                    INNER JOIN "VitalSignDetails" vsd ON vsd."vitalSignId" = vs."id" AND vsd."IsDeleted" = FALSE
                    INNER JOIN "VitalSignTypes" vst ON vst."id" = vsd."vitalSignTypeId" AND vst."isDeleted" = FALSE
                    WHERE vsd."vitalSignTypeId" IN (26)
                    ORDER BY vs."createdDate" DESC
                    LIMIT 1
                );

                CREATE VIEW "vw_MmseAssessmentDue" AS
                SELECT * FROM 
                (
                    SELECT vs."patientId", vs."source", vs."icaId", vs."createdDate", vs."createdBy", 
                           vs."updatedDate", vs."updatedBy", vst."name" AS "AssessmentName", 
                           vs."createdDate" + INTERVAL '6 months' AS "DueDate"
                    FROM "VitalSigns" vs
                    INNER JOIN "VitalSignDetails" vsd ON vsd."vitalSignId" = vs."id" AND vsd."IsDeleted" = FALSE
                    INNER JOIN "VitalSignTypes" vst ON vst."id" = vsd."vitalSignTypeId" AND vst."isDeleted" = FALSE
                    WHERE vsd."vitalSignTypeId" IN (27)
                    ORDER BY vs."createdDate" DESC
                    LIMIT 1
                );

                CREATE VIEW "vw_BradenScaleAssessmentDue" AS
                SELECT * FROM 
                (
                    SELECT vs."patientId", vs."source", vs."icaId", vs."createdDate", vs."createdBy", 
                           vs."updatedDate", vs."updatedBy", vst."name" AS "AssessmentName", 
                           vs."createdDate" + INTERVAL '6 months' AS "DueDate"
                    FROM "VitalSigns" vs
                    INNER JOIN "VitalSignDetails" vsd ON vsd."vitalSignId" = vs."id" AND vsd."IsDeleted" = FALSE
                    INNER JOIN "VitalSignTypes" vst ON vst."id" = vsd."vitalSignTypeId" AND vst."isDeleted" = FALSE
                    WHERE vsd."vitalSignTypeId" IN (28)
                    ORDER BY vs."createdDate" DESC
                    LIMIT 1
                );

                CREATE VIEW "vw_GcsAssessmentDue" AS
                SELECT * FROM 
                (
                    SELECT vs."patientId", vs."source", vs."icaId", vs."createdDate", vs."createdBy", 
                           vs."updatedDate", vs."updatedBy", vst."name" AS "AssessmentName", 
                           vs."createdDate" + INTERVAL '6 months' AS "DueDate"
                    FROM "VitalSigns" vs
                    INNER JOIN "VitalSignDetails" vsd ON vsd."vitalSignId" = vs."id" AND vsd."IsDeleted" = FALSE
                    INNER JOIN "VitalSignTypes" vst ON vst."id" = vsd."vitalSignTypeId" AND vst."isDeleted" = FALSE
                    WHERE vsd."vitalSignTypeId" IN (29)
                    ORDER BY vs."createdDate" DESC
                    LIMIT 1
                );

                CREATE VIEW "vw_AssessmentDue" AS
                SELECT * FROM "vw_AmtAssessmentDue"
                UNION
                SELECT * FROM "vw_RafAssessmentDue"
                UNION
                SELECT * FROM "vw_MbiAssessmentDue"
                UNION
                SELECT * FROM "vw_MfsAssessmentDue"
                UNION
                SELECT * FROM "vw_EbasDepAssessmentDue"
                UNION
                SELECT * FROM "vw_MmseAssessmentDue"
                UNION
                SELECT * FROM "vw_BradenScaleAssessmentDue"
                UNION
                SELECT * FROM "vw_GcsAssessmentDue";
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                DROP VIEW IF EXISTS "vw_AmtAssessmentDue";
                DROP VIEW IF EXISTS "vw_RafAssessmentDue";
                DROP VIEW IF EXISTS "vw_MbiAssessmentDue";
                DROP VIEW IF EXISTS "vw_MfsAssessmentDue";
                DROP VIEW IF EXISTS "vw_EbasDepAssessmentDue";
                DROP VIEW IF EXISTS "vw_MmseAssessmentDue";
                DROP VIEW IF EXISTS "vw_BradenScaleAssessmentDue";
                DROP VIEW IF EXISTS "vw_GcsAssessmentDue";
                DROP VIEW IF EXISTS "vw_AssessmentDue";
                """);
        }
    }
}
