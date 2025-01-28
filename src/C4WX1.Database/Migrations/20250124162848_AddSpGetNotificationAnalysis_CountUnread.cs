using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4WX1.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddSpGetNotificationAnalysis_CountUnread : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE OR REPLACE FUNCTION "fn_SpGetNotificationAnalysis_CountUnread"(user_id_input INT, facility_id_input INT)
                RETURNS BIGINT AS $$
                DECLARE
                    notification_count BIGINT;
                BEGIN
                	SELECT COUNT(1)
                	INTO notification_count
                	FROM "Notifications" 
                	WHERE "isDeleted" IS FALSE
                		AND "isRead" IS FALSE
                		AND "userId" = user_id_input
                		AND "FacilityID_FK" = facility_id_input;
                
                	RETURN notification_count;
                END;
                $$ LANGUAGE plpgsql;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                DROP FUNCTION IF EXISTS "fn_SpGetNotificationAnalysis_CountUnread";
                """);
        }
    }
}
