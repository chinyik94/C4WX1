using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4WX1.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddFnCanDeleteProblemList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE OR REPLACE FUNCTION "fn_CanDeleteProblemList" (
                    problem_list_id INTEGER
                )
                RETURNS BOOLEAN AS $$
                BEGIN
                    IF EXISTS (
                        SELECT 1
                        FROM "CarePlanSubProblemList" cpspl
                        INNER JOIN "ProblemList" pl ON cpspl."ProblemListID_FK" = pl."ProblemListID"
                        WHERE pl."IsDeleted" = FALSE AND cpspl."ProblemListID_FK" = problem_list_id
                    ) THEN
                        RETURN FALSE;
                    END IF;
                
                    RETURN TRUE;
                END;
                $$ LANGUAGE plpgsql;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                DROP FUNCTION IF EXISTS "fn_CanDeleteProblemList";
                """);
        }
    }
}
