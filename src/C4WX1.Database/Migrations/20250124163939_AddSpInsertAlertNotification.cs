using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4WX1.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddSpInsertAlertNotification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE OR REPLACE FUNCTION "fn_SpInsertAlertNotification"(
                    message_param VARCHAR(1000),
                    title_param VARCHAR(300),
                    user_id_param INTEGER,
                    task_id_param INTEGER,
                    is_critical_param BOOLEAN
                ) 
                RETURNS VOID
                LANGUAGE plpgsql
                AS $$
                BEGIN
                	INSERT INTO "APNSNotification"(
                		"NotificationMessage",
                		"NotificationTitle",
                		"UserID",
                		"IsCritical",
                		"TaskID"
                	)
                	VALUES(
                		message_param,
                		title_param,
                		user_id_param,
                		is_critical_param,
                		task_id_param
                	);
                END;
                $$;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                DROP FUNCTION IF EXISTS "fn_SpInsertAlertNotification";
                """);
        }
    }
}
