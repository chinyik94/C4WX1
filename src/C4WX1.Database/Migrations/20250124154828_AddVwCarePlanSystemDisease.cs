using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4WX1.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddVwCarePlanSystemDisease : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE OR REPLACE VIEW "vw_CarePlanSystemDisease" AS
                SELECT cp."CarePlanID", cpd."SystemID_FK", cpd."DiseaseID_FK", cp."IsDeleted", cp."IsClosed"
                FROM "CarePlan" cp
                INNER JOIN "CarePlanSub" cps
                    ON cps."CarePlanID_FK" = cp."CarePlanID"
                    AND cps."IsDeleted" IS FALSE
                INNER JOIN "CarePlanDetail" cpd
                    ON cps."CarePlanSubID" = cpd."CarePlanSubID_FK";
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                DROP VIEW IF EXISTS "vw_CarePlanSystemDisease"
                """);
        }
    }
}
