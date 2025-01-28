using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4WX1.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddFnCanDeleteActivity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE OR REPLACE FUNCTION "fn_CanDeleteActivity"(
                    activity_id INTEGER
                )
                RETURNS BOOLEAN
                LANGUAGE plpgsql
                AS $$
                BEGIN
                    -- Check if the activity is referenced in "CarePlanSubActivity"
                    IF EXISTS (
                        SELECT 1
                        FROM "CarePlanSubActivity" cpsa
                        INNER JOIN "Activity" a ON cpsa."ActivityID_FK" = a."ActivityID"
                        WHERE a."IsDeleted" = FALSE 
                          AND cpsa."ActivityID_FK" = activity_id
                    ) THEN
                        RETURN FALSE;
                    END IF;
                
                    RETURN TRUE;
                END;
                $$;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                DROP FUNCTION IF EXISTS "fn_CanDeleteActivity";
                """);
        }
    }
}
