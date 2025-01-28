using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4WX1.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddFnRecurrenceMonthlyDays : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE OR REPLACE FUNCTION "fn_RecurrenceMonthlyDays"(
                    ref_date timestamp,
                    check_date timestamp,
                    interval_input integer,
                    interval_flag integer
                )
                RETURNS boolean
                LANGUAGE plpgsql
                AS $$
                BEGIN
                    RETURN (EXTRACT(MONTH FROM check_date)::integer - 
                            EXTRACT(MONTH FROM ref_date)::integer + 
                            (EXTRACT(YEAR FROM check_date)::integer - 
                             EXTRACT(YEAR FROM ref_date)::integer) * 12) % interval_input = 0;
                END;
                $$;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                DROP FUNCTION IF EXISTS "fn_RecurrenceMonthlyDays";
                """);
        }
    }
}
