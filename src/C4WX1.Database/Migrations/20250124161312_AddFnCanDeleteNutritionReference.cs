using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4WX1.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddFnCanDeleteNutritionReference : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE OR REPLACE FUNCTION "fn_CanDeleteNutritionReference" (
                    reference_id INTEGER
                )
                RETURNS BOOLEAN AS $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 
                        FROM "NutritionTask" nt
                        INNER JOIN "NutritionTaskReference" f ON nt."AmountReferenceID_FK" = f."ReferenceID"
                        WHERE f."IsDeleted" = FALSE AND f."ReferenceID" = reference_id
                    UNION
                        SELECT 1 
                        FROM "NutritionTask" nt
                        INNER JOIN "NutritionTaskReference" f ON nt."TypeReferenceID_FK" = f."ReferenceID"
                        WHERE f."IsDeleted" = FALSE AND f."ReferenceID" = reference_id
                    UNION
                        SELECT 1 
                        FROM "NutritionTask" nt
                        INNER JOIN "NutritionTaskReference" f ON nt."ColorReferenceID_FK" = f."ReferenceID"
                        WHERE f."IsDeleted" = FALSE AND f."ReferenceID" = reference_id
                    ) THEN
                        RETURN FALSE;
                    END IF;
                
                    RETURN TRUE;
                END;
                $$ LANGUAGE plpgsql;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                DROP FUNCTION IF EXISTS "fn_CanDeleteNutritionReference";
                """);
        }
    }
}
