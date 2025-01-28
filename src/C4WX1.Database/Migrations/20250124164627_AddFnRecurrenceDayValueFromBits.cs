using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4WX1.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddFnRecurrenceDayValueFromBits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE OR REPLACE FUNCTION "fn_RecurrenceDayValueFromBits"(
                    check_date timestamp
                )
                RETURNS integer
                LANGUAGE plpgsql
                AS $$
                BEGIN
                    RETURN POWER(2, EXTRACT(DOW FROM check_date)::integer);
                END;
                $$;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                DROP FUNCTION IF EXISTS "fn_RecurrenceDayValueFromBits";
                """);
        }
    }
}
