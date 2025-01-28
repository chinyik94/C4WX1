using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4WX1.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddFnCanDeleteCPGoals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE OR REPLACE FUNCTION "fn_CanDeleteCPGoals" (
                    id INTEGER
                )
                RETURNS BOOLEAN AS $$
                BEGIN
                    IF EXISTS (
                        SELECT 1
                        FROM "CarePlanSubCPGoals" cpsa
                        INNER JOIN "CPGoals" a ON cpsa."CPGoalsID_FK" = a."CPGoalsID"
                        WHERE a."IsDeleted" IS FALSE AND cpsa."CPGoalsID_FK" = id
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
                DROP FUNCTION IF EXISTS "fn_CanDeleteCPGoals";
                """);
        }
    }
}
