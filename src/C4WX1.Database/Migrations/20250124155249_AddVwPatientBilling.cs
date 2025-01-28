using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4WX1.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddVwPatientBilling : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE OR REPLACE VIEW "vw_PatientBilling" AS
                SELECT 
                  p."PatientProfileID_FK", 
                  p."Firstname" || ' ' || p."Lastname" AS "PatientName", 
                  p."Email", 
                  pf."BillingAddress1", 
                  pf."BillingAddress2", 
                  pf."BillingAddress3", 
                  pf."BillingPostalCode"
                FROM "Patient" p
                  INNER JOIN "PatientProfile" pf ON pf."PatientProfileID" = p."PatientProfileID_FK";
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                DROP VIEW IF EXISTS "vw_PatientBilling";
                """);
        }
    }
}
