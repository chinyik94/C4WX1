using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4WX1.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddSpGetPushScore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE OR REPLACE FUNCTION "fn_spGetPushScore"(
                    visit_id_param INTEGER
                )
                RETURNS TABLE (
                    "PatientWoundVisitID" INTEGER,
                    "LengthWidth" DECIMAL,
                    "LengthXWidthScore" INTEGER,
                    "Exudate" VARCHAR(50),
                    "ExudateAmountScore" INTEGER,
                    "NecrosisScore" INTEGER,
                    "SloughScore" INTEGER,
                    "GranulationScore" INTEGER,
                    "EpithelizingScore" INTEGER,
                    "OtherScore" INTEGER,
                    "PushScore" INTEGER
                ) AS $$
                BEGIN
                    RETURN QUERY
                    WITH wound_data AS (
                        SELECT 
                            "wv"."PatientWoundVisitID",
                            "wv"."SizeLength" * "wv"."SizeWidth" AS "LengthWidth",
                            "wv"."Exudate",
                            -- Length x Width Score calculation
                            CASE 
                                WHEN "wv"."SizeLength" * "wv"."SizeWidth" > 24.0 THEN 10
                                WHEN "wv"."SizeLength" * "wv"."SizeWidth" > 12.0 THEN 9
                                WHEN "wv"."SizeLength" * "wv"."SizeWidth" > 8.0 THEN 8
                                WHEN "wv"."SizeLength" * "wv"."SizeWidth" > 4.0 THEN 7
                                WHEN "wv"."SizeLength" * "wv"."SizeWidth" > 3.0 THEN 6
                                WHEN "wv"."SizeLength" * "wv"."SizeWidth" > 2.0 THEN 5
                                WHEN "wv"."SizeLength" * "wv"."SizeWidth" > 1.0 THEN 4
                                WHEN "wv"."SizeLength" * "wv"."SizeWidth" >= 0.7 THEN 3
                                WHEN "wv"."SizeLength" * "wv"."SizeWidth" >= 0.3 THEN 2
                                WHEN "wv"."SizeLength" * "wv"."SizeWidth" > 0 THEN 1
                                ELSE 0
                            END AS "LengthXWidthScore",
                            -- Exudate Amount Score calculation
                            CASE 
                                WHEN "wv"."Exudate" LIKE '%Excessive%' THEN 3
                                WHEN "wv"."Exudate" LIKE '%Moderate%' THEN 2
                                WHEN "wv"."Exudate" LIKE '%Mild%' THEN 1
                                ELSE 0
                            END AS "ExudateAmountScore",
                            -- Other scores calculation
                            CASE WHEN "wv"."TC_Auto_Necrosis" > 0 THEN 4 ELSE 0 END AS "NecrosisScore",
                            CASE WHEN "wv"."TC_Slough" > 0 THEN 3 ELSE 0 END AS "SloughScore",
                            CASE WHEN "wv"."TC_Auto_Granulation" > 0 THEN 2 ELSE 0 END AS "GranulationScore",
                            CASE WHEN "wv"."TC_Auto_Epithelizing" > 0 THEN 1 ELSE 0 END AS "EpithelizingScore",
                            CASE WHEN "wv"."TC_Others" > 0 THEN 1 ELSE 0 END AS "OtherScore"
                        FROM "PatientWoundVisit" "wv"
                        WHERE "wv"."IsDeleted" = FALSE 
                        AND "wv"."PatientWoundVisitID" = visit_id_param
                    )
                    SELECT 
                        wd."PatientWoundVisitID",
                        wd."LengthWidth",
                        wd."LengthXWidthScore",
                        wd."Exudate",
                        wd."ExudateAmountScore",
                        wd."NecrosisScore",
                        wd."SloughScore",
                        wd."GranulationScore",
                        wd."EpithelizingScore",
                        wd."OtherScore",
                        wd."LengthXWidthScore" + wd."ExudateAmountScore" + wd."NecrosisScore" + 
                        wd."SloughScore" + wd."GranulationScore" + wd."EpithelizingScore" AS "PushScore"
                    FROM wound_data wd;
                END;
                $$ LANGUAGE plpgsql;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                DROP FUNCTION IF EXISTS "fn_spGetPushScore";
                """);
        }
    }
}
