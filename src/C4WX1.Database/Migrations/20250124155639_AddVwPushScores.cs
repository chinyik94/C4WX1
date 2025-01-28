using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4WX1.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddVwPushScores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE OR REPLACE VIEW "vw_PushScores" AS
                WITH PushScores_CTE AS (
                  SELECT 
                    "wv"."PatientWoundVisitID", 
                    CASE 
                      WHEN ("SizeLength" * "SizeWidth") > 24.0 THEN 10
                      WHEN ("SizeLength" * "SizeWidth") > 12.0 THEN 9
                      WHEN ("SizeLength" * "SizeWidth") > 8.0 THEN 8
                      WHEN ("SizeLength" * "SizeWidth") > 4.0 THEN 7
                      WHEN ("SizeLength" * "SizeWidth") > 3.0 THEN 6
                      WHEN ("SizeLength" * "SizeWidth") > 2.0 THEN 5
                      WHEN ("SizeLength" * "SizeWidth") > 1.0 THEN 4
                      WHEN ("SizeLength" * "SizeWidth") >= 0.7 THEN 3
                      WHEN ("SizeLength" * "SizeWidth") >= 0.3 THEN 2
                      WHEN ("SizeLength" * "SizeWidth") > 0 THEN 1
                      ELSE 0
                    END AS "LengthXWidthScore",
                    CASE 
                      WHEN "Exudate" LIKE '%Excessive%' THEN 3
                      WHEN "Exudate" LIKE '%Moderate%' THEN 2
                      WHEN "Exudate" LIKE '%Mild%' THEN 1
                      ELSE 0
                    END AS "ExudateAmountScore",
                    CASE
                      WHEN "TC_Auto_Necrosis" > 0 THEN 4
                      WHEN "TC_Auto_Slough" > 0 THEN 3
                      WHEN "TC_Auto_Granulation" > 0 THEN 2
                      WHEN "TC_Auto_Epithelizing" > 0 THEN 1
                      ELSE 0
                    END AS "TissueTypeScore"
                  FROM "PatientWoundVisit" "wv"
                  WHERE "wv"."IsDeleted" IS FALSE
                )
                SELECT 
                  "PatientWoundVisitID", 
                  "LengthXWidthScore", 
                  "ExudateAmountScore", 
                  "TissueTypeScore",
                  "LengthXWidthScore" + "ExudateAmountScore" + "TissueTypeScore" AS "TotalScore"
                FROM PushScores_CTE;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                DROP VIEW IF EXISTS "vw_PushScores";
                """);
        }
    }
}
