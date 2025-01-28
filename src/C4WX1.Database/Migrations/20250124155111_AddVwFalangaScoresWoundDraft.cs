using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4WX1.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddVwFalangaScoresWoundDraft : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE OR REPLACE VIEW "vw_FalangaScores_WoundDraft" AS
                WITH FalangaScore AS (
                    SELECT "PatientWoundDraftID", 
                           "Edges" AS "HealingEdges",
                           CASE 
                               WHEN "Edges" = 'Rolled' THEN 0
                               WHEN "Edges" = 'Undermining' THEN 0
                               WHEN "Edges" = 'Maceration' THEN 1
                               WHEN "Edges" = 'Dehydration' THEN 1
                               WHEN "Edges" = 'Others' THEN 1
                               WHEN "Edges" = 'Healthy' THEN 2
                               WHEN "Edges" = 'Inflamed' THEN 2
                               ELSE 0
                           END AS "HealingEdges_Score",
                           CONCAT("Necrosis", ' %') AS "BlackEschar",
                           CASE 
                               WHEN "Necrosis" > 25 THEN 0
                               WHEN "Necrosis" > 0 THEN 1
                               WHEN "Necrosis" = 0 THEN 2
                               ELSE 0
                           END AS "BlackEschar_Score",
                           CASE 
                               WHEN "Granulation" = 0 THEN CONCAT('Granulation = 0% , Depth = ', CONCAT("SizeDepth", ' cm'))
                               ELSE CONCAT("SizeDepth", ' cm')
                           END AS "GreatestWoundDepth",
                           CASE
                               WHEN "Granulation" = 0 THEN 0
                               WHEN "SizeDepth" > 2 THEN 0
                               WHEN "SizeDepth" >= 0.5 THEN 1
                               WHEN "SizeDepth" < 0.5 THEN 2
                               ELSE 0
                           END AS "GreatestWoundDepth_Score",
                           "Exudate" AS "ExudateAmount",
                           CASE 
                               WHEN "Exudate" LIKE '%Excessive%' THEN 0
                               WHEN "Exudate" LIKE '%Moderate%' THEN 1
                               WHEN "Exudate" LIKE '%Mild%' THEN 2
                               WHEN "Exudate" LIKE '%Absent%' THEN 2
                               ELSE 0
                           END AS "ExudateAmount_Score",
                           "IsSwelling" AS "Edema",
                           CASE 
                               WHEN "IsSwelling" IS TRUE THEN 0
                               WHEN "IsSwelling" IS FALSE THEN 2
                               ELSE 1
                           END AS "Edema_Score",
                           "PeriWound" AS "PeriwoundDermatitis",
                           CASE 
                               WHEN "PeriWound" = 'Maceration' THEN 0
                               WHEN "PeriWound" = 'Dryness' THEN 0
                               WHEN "PeriWound" = 'Excoriation/ Erosion' THEN 1
                               WHEN "PeriWound" = 'Bruise' THEN 1
                               WHEN "PeriWound" = 'Blister' THEN 1
                               WHEN "PeriWound" = 'Others' THEN 1
                               WHEN "PeriWound" = 'Healthy' THEN 2
                               ELSE 0
                           END AS "PeriwoundDermatitis_Score",
                           "PeriWound" AS "PeriwoundCallousFibrosis",
                           CASE 
                               WHEN "PeriWound" = 'Excoriation/ Erosion' THEN 0
                               WHEN "PeriWound" = 'Bruise' THEN 0
                               WHEN "PeriWound" = 'Blister' THEN 0
                               WHEN "PeriWound" = 'Maceration' THEN 1
                               WHEN "PeriWound" = 'Dryness' THEN 1
                               WHEN "PeriWound" = 'Others' THEN 1
                               WHEN "PeriWound" = 'Healthy' THEN 2
                               ELSE 0
                           END AS "PeriwoundCallousFibrosis_Score",
                           CONCAT("Epithelizing", ' %') AS "PinkWoundBed",
                           CASE
                               WHEN "Epithelizing" < 50 THEN 0
                               WHEN "Epithelizing" <= 75 THEN 1
                               WHEN "Epithelizing" > 75 THEN 2
                               ELSE 2
                           END AS "PinkWoundBed_Score"
                    FROM "PatientWoundDraft"
                    WHERE "IsDeleted" IS FALSE
                )
                SELECT "PatientWoundDraftID", 
                       "HealingEdges", 
                       "HealingEdges_Score", 
                       "BlackEschar", 
                       "BlackEschar_Score", 
                       "GreatestWoundDepth", 
                       "GreatestWoundDepth_Score", 
                       "ExudateAmount", 
                       "ExudateAmount_Score", 
                       "Edema", 
                       "Edema_Score", 
                       "PeriwoundDermatitis", 
                       "PeriwoundDermatitis_Score", 
                       "PeriwoundCallousFibrosis", 
                       "PeriwoundCallousFibrosis_Score", 
                       "PinkWoundBed", 
                       "PinkWoundBed_Score", 
                       ("HealingEdges_Score" + "BlackEschar_Score" + "GreatestWoundDepth_Score" + "ExudateAmount_Score" + 
                        "Edema_Score" + "PeriwoundDermatitis_Score" + "PeriwoundCallousFibrosis_Score" + "PinkWoundBed_Score") AS "TotalScore"
                FROM FalangaScore;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                DROP VIEW IF EXISTS "vw_FalangaScores_WoundDraft";
                """);
        }
    }
}
