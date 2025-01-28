using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4WX1.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddFnCanDeleteCarePlanSubGoal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE OR REPLACE FUNCTION "fn_CanDeleteCarePlanSubGoal"(
                    care_plan_sub_goal_id INTEGER
                )
                RETURNS BOOLEAN
                LANGUAGE plpgsql
                AS $$
                BEGIN
                    -- Check if the care plan sub-goal is referenced and not deleted
                    IF EXISTS (
                        SELECT 1
                        FROM "CarePlanSubGoal" a
                        WHERE a."IsDeleted" = FALSE 
                          AND a."CarePlanSubGoalID" = care_plan_sub_goal_id
                    ) THEN
                        RETURN FALSE;
                    END IF;
                
                    -- Return TRUE if it can be deleted
                    RETURN TRUE;
                END;
                $$;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                DROP FUNCTION IF EXISTS "fn_CanDeleteCarePlanSubGoal";
                """);
        }
    }
}
