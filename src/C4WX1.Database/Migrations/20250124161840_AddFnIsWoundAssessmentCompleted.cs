using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4WX1.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddFnIsWoundAssessmentCompleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE OR REPLACE FUNCTION "fn_IsWoundAssessmentCompleted"(wound_visit_id INT)
                RETURNS BOOLEAN AS $$
                BEGIN
                    -- Check if all required fields in PatientWoundVisit are filled
                    IF EXISTS (
                        SELECT 1
                        FROM "PatientWoundVisit"
                        WHERE "PatientWoundVisitID" = wound_visit_id
                          AND "SizeLength" IS NOT NULL
                          AND "SizeDepth" IS NOT NULL
                          AND "SizeWidth" IS NOT NULL
                          AND COALESCE("PeriWound", '') <> ''
                          AND COALESCE("Edges", '') <> ''
                          AND COALESCE("Exudate", '') <> ''
                          AND "Suffering" IS NOT NULL
                          AND "IsRedness" IS NOT NULL
                          AND "IsSwelling" IS NOT NULL
                          AND "IsWarmToTouch" IS NOT NULL
                          AND "IsSmell" IS NOT NULL
                          AND "TC_Auto_Granulation" IS NOT NULL
                          AND "TC_Auto_Slough" IS NOT NULL
                          AND "TC_Auto_Necrosis" IS NOT NULL
                          AND "TC_Auto_Epithelizing" IS NOT NULL
                    )
                    AND EXISTS (
                        SELECT 1
                        FROM "PatientWoundVisitTreatmentList"
                        WHERE "PatientWoundVisitID_FK" = wound_visit_id
                    ) THEN
                        RETURN TRUE;
                    END IF;
                
                    RETURN FALSE;
                END;
                $$ LANGUAGE plpgsql;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                DROP FUNCTION IF EXISTS "fn_IsWoundAssessmentCompleted";
                """);
        }
    }
}
