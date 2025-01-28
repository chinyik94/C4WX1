using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4WX1.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddFnCanDeleteIntervention : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE OR REPLACE FUNCTION "fn_CanDeleteIntervention" (
                    intervention_id INTEGER
                )
                RETURNS BOOLEAN AS $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 
                        FROM "CarePlanSubIntervention" cpsa
                        INNER JOIN "Intervention" a ON cpsa."InterventionID_FK" = a."InterventionID"
                        WHERE a."IsDeleted" = FALSE AND cpsa."InterventionID_FK" = intervention_id
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
                DROP FUNCTION IF EXISTS "fn_CanDeleteIntervention";
                """);
        }
    }
}
