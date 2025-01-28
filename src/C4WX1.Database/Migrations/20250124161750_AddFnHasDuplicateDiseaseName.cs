using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4WX1.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddFnHasDuplicateDiseaseName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE OR REPLACE FUNCTION "fn_HasDuplicateDiseaseName"(disease_id INT)
                RETURNS BOOLEAN AS $$
                DECLARE
                    disease_name VARCHAR(255);
                BEGIN
                    -- Retrieve the disease name for the given disease_id
                    SELECT "DiseaseName"
                    INTO disease_name
                    FROM "Disease"
                    WHERE NOT "IsDeleted" AND "DiseaseID" = disease_id;
                
                    -- Check for duplicates with the same name but a different ID
                    RETURN EXISTS (
                        SELECT 1
                        FROM "Disease"
                        WHERE NOT "IsDeleted"
                          AND "DiseaseID" <> disease_id
                          AND "DiseaseName" = disease_name
                    );
                END;
                $$ LANGUAGE plpgsql;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                DROP FUNCTION IF EXISTS "fn_HasDuplicateDiseaseName";
                """);
        }
    }
}
