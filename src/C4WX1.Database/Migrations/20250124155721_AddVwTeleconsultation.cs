using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4WX1.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddVwTeleconsultation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE OR REPLACE VIEW "vw_Teleconsultation" AS  
                SELECT 
                  "tul"."TaskID_FK" AS "TaskID", 
                  "tul"."UserID_FK" AS "UserID", 
                  "t"."PatientID_FK" AS "PatientID", 
                  "tul"."StartDate", 
                  "tul"."EndDate"
                FROM "TaskUserLog" "tul"
                INNER JOIN "Task" "t" ON "t"."TaskID" = "tul"."TaskID_FK"
                  AND "t"."ActionTypeID_FK" = (
                    SELECT "CodeId" 
                    FROM "Code" 
                    WHERE "CodeTypeId_FK" = 1 
                    AND "CodeName" = 'Teleconsultation'
                  )
                  AND "tul"."IsDeleted" IS FALSE;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                DROP VIEW IF EXISTS "vw_Teleconsultation";
                """);
        }
    }
}
