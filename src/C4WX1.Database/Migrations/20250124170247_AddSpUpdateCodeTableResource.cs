using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4WX1.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddSpUpdateCodeTableResource : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE OR REPLACE FUNCTION "fn_SpUpdateCodeTableResource"(
                    code_id_param INTEGER
                )
                RETURNS VOID AS $$
                BEGIN
                    -- Check if resource exists for the given code
                    IF EXISTS (SELECT 1 FROM "Resource" WHERE "CodeId" = code_id_param) THEN
                        -- Update existing resource
                        UPDATE "Resource" 
                        SET "CodeValue" = (
                            SELECT "CodeName" 
                            FROM "Code" 
                            WHERE "CodeId" = code_id_param
                        )
                        WHERE "CodeId" = code_id_param 
                        AND "LanguageId" = 1;
                    ELSE
                        -- Insert new resource
                        INSERT INTO "Resource" ("CodeId", "LanguageId", "CodeValue", "Details")
                        SELECT 
                            cd."CodeId",
                            1,
                            cd."CodeName",
                            ''
                        FROM "Code" cd
                        WHERE cd."CodeId" = code_id_param
                            AND NOT cd."IsDeleted"
                            AND NOT EXISTS (
                                SELECT 1 
                                FROM "Resource" r 
                                WHERE r."CodeId" = cd."CodeId" 
                                AND r."LanguageId" = 1
                            );
                    END IF;
                END;
                $$ LANGUAGE plpgsql;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                DROP FUNCTION IF EXISTS "fn_SpUpdateCodeTableResource";
                """);
        }
    }
}
