using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4WX1.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddFnCanDeleteBranch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE OR REPLACE FUNCTION "fn_CanDeleteBranch"(
                    branch_id INTEGER
                )
                RETURNS BOOLEAN
                LANGUAGE plpgsql
                AS $$
                BEGIN
                    -- Check if the branch cannot be deleted based on the conditions
                    IF EXISTS (
                        SELECT 1
                        FROM "Branch"
                        WHERE "IsDeleted" = FALSE 
                          AND "BranchID" = branch_id 
                          AND ("IsSystemUsed" = TRUE OR "Status" IN ('Active', 'Locked'))
                    ) THEN
                        RETURN FALSE;
                    END IF;
                
                    -- Uncomment if needed for additional checks
                    -- IF EXISTS (
                    --     SELECT 1
                    --     FROM "Users" u
                    --     INNER JOIN "UserBranch" ub ON u."UserID" = ub."UserID_FK"
                    --     INNER JOIN "Branch" b ON ub."BranchID_FK" = b."BranchID"
                    --     WHERE u."IsDeleted" = FALSE 
                    --       AND b."IsDeleted" = FALSE 
                    --       AND ub."BranchID_FK" = branch_id
                    -- ) THEN
                    --     RETURN FALSE;
                    -- END IF;
                
                    -- Return TRUE if the branch can be deleted
                    RETURN TRUE;
                END;
                $$;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                DROP FUNCTION IF EXISTS "fn_CanDeleteBranch";
                """);
        }
    }
}
