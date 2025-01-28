using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4WX1.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddFnRecurrenceNearestMonthDay : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE OR REPLACE FUNCTION "fn_RecurrenceNearestMonthDay"(
                    start_date timestamp,
                    day_num integer
                )
                RETURNS integer
                LANGUAGE plpgsql
                AS $$
                BEGIN
                    RETURN LEAST(day_num, 
                                 EXTRACT(DAY FROM 
                                     (DATE_TRUNC('MONTH', start_date) + INTERVAL '1 MONTH - 1 day')
                                 )::integer);
                END;
                $$;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                DROP FUNCTION IF EXISTS "fn_RecurrenceNearestMonthDay";
                """);
        }
    }
}
