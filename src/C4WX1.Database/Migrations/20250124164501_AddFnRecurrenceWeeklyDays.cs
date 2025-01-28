using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4WX1.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddFnRecurrenceWeeklyDays : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE OR REPLACE FUNCTION "fn_RecurrenceWeeklyDays"(
                    start_date_input timestamp,
                    check_date_input timestamp,
                    interval_input integer
                )
                RETURNS boolean
                LANGUAGE plpgsql
                AS $$
                BEGIN
                    RETURN EXTRACT(WEEK FROM check_date_input - start_date_input)::integer % interval_input = 0;
                END;
                $$;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                DROP FUNCTION IF EXISTS "fn_RecurrenceWeeklyDays";
                """);
        }
    }
}
