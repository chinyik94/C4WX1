using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4WX1.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddSpUpdateTreatmentListItemStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE OR REPLACE FUNCTION "fn_SpUpdateTreatmentListItemStatus"()
                RETURNS VOID AS $$
                BEGIN
                    UPDATE "TreatmentListItem"
                    SET "IsActive" = FALSE
                    WHERE "StartDate" IS NOT NULL 
                        AND "EndDate" IS NOT NULL;
                END;
                $$ LANGUAGE plpgsql;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                DROP FUNCTION IF EXISTS "fn_SpUpdateTreatmentListItemStatus";
                """);
        }
    }
}
