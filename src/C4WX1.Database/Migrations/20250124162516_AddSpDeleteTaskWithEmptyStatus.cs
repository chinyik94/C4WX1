using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4WX1.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddSpDeleteTaskWithEmptyStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE OR REPLACE FUNCTION "fn_SpDeleteTaskWithEmptyStatus"(
                    task_id_param INTEGER,
                    current_user_id_param INTEGER
                )
                RETURNS VOID
                LANGUAGE plpgsql
                AS $$
                BEGIN
                    UPDATE "TaskUserLog"
                    SET 
                        "IsDeleted" = TRUE,
                        "ModifiedDate" = CURRENT_TIMESTAMP,
                        "ModifiedBy_FK" = current_user_id_param
                    WHERE 
                        NOT "IsDeleted" 
                        AND "TaskID_FK" = task_id_param 
                        AND "Status" IS NULL;
                END;
                $$;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                DROP FUNCTION IF EXISTS "fn_SpDeleteTaskWithEmptyStatus";
                """);
        }
    }
}
