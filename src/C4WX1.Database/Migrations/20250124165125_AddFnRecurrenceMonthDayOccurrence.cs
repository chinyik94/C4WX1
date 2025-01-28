using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4WX1.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddFnRecurrenceMonthDayOccurrence : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE OR REPLACE FUNCTION "fn_RecurrenceMonthDayOccurrence"(
                    check_date timestamp,
                    day_num integer,
                    interval_input integer
                )
                RETURNS timestamp
                LANGUAGE plpgsql
                AS $$
                DECLARE
                    first_day timestamp;
                    result_date timestamp;
                    week_num integer;
                BEGIN
                    first_day := DATE_TRUNC('MONTH', check_date);
                    week_num := CEIL(day_num::float / 7);
                    
                    IF day_num > 0 THEN
                        result_date := first_day + 
                                      ((week_num - 1) * INTERVAL '7 days') +
                                      ((day_num % 7) * INTERVAL '1 day');
                    ELSE
                        result_date := (DATE_TRUNC('MONTH', check_date) + INTERVAL '1 MONTH - 1 day') +
                                      ((week_num + 1) * INTERVAL '7 days') +
                                      ((day_num % 7) * INTERVAL '1 day');
                    END IF;
                    
                    RETURN result_date;
                END;
                $$;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                DROP FUNCTION IF EXISTS "fn_RecurrenceMonthDayOccurrence";
                """);
        }
    }
}
