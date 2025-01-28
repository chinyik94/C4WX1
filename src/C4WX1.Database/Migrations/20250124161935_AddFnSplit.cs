using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4WX1.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddFnSplit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE OR REPLACE FUNCTION "fn_Split"(
                    input_string text,
                    delimiter_char text
                )
                RETURNS TABLE (Value text) AS $$
                BEGIN
                    -- Use string_to_table to split the string efficiently
                    -- Trim the delimiter from the end if it exists
                    RETURN QUERY 
                    WITH normalized_input AS (
                        SELECT CASE 
                            WHEN input_string IS NULL THEN NULL
                            WHEN RIGHT(input_string, LENGTH(delimiter_char)) = delimiter_char 
                                THEN input_string
                            ELSE input_string || delimiter_char
                        END AS processed_string
                    )
                    SELECT NULLIF(TRIM(unnested_value), '') AS Value
                    FROM normalized_input,
                    LATERAL string_to_table(
                        processed_string,
                        delimiter_char
                    ) AS t(unnested_value)
                    WHERE unnested_value IS NOT NULL
                    AND TRIM(unnested_value) <> '';
                
                END;
                $$ LANGUAGE plpgsql;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                DROP FUNCTION IF EXISTS "fn_Split";
                """);
        }
    }
}
