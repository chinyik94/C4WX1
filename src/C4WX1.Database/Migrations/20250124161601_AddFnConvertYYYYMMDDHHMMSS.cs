using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4WX1.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddFnConvertYYYYMMDDHHMMSS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE OR REPLACE FUNCTION "fn_ConvertYYYYMMDDHHMMSS" (
                    input_date TIMESTAMP
                )
                RETURNS VARCHAR(18) AS $$
                DECLARE
                    rtn_date VARCHAR(18);
                BEGIN
                    -- Convert the input_date to the format YYYYMMDDHHMMSS
                    rtn_date := TO_CHAR(input_date, 'YYYYMMDD') || TO_CHAR(input_date, 'HH24MI') || TO_CHAR(input_date, 'SS');
                    RETURN rtn_date;
                END;
                $$ LANGUAGE plpgsql;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                DROP FUNCTION IF EXISTS "fn_ConvertYYYYMMDDHHMMSS";
                """);
        }
    }
}
