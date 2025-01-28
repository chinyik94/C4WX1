using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4WX1.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddSpGetNotificationAnalysis_Count : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE OR REPLACE FUNCTION "fn_SpGetNotificationAnalysis_Count"(user_id_input INT)
                RETURNS BIGINT AS $$
                DECLARE
                    notification_count BIGINT;
                BEGIN
                	SELECT COUNT(1)
                	INTO notification_count
                	FROM "Notifications" n
                		LEFT JOIN "NotificationVitalSignDetails" nvsd ON n."id" = nvsd."notificationId"
                		LEFT JOIN "VitalSignDetails" vsd ON nvsd."VitalSignDetailId" = vsd."id"
                		LEFT JOIN "VitalSigns" vs ON vs."id" = vsd."vitalSignId"
                		LEFT JOIN "Patient" vp ON vp."PatientID" = vs."patientId"
                		LEFT JOIN "VitalSignTypes" vst ON vst."id" = vsd."vitalSignTypeId"
                		
                		LEFT JOIN "NotificationChat" nc ON n."id" = nc."NotificationId_FK"
                		LEFT JOIN "Chat" ct ON ct."ChatID" = nc."ChatID_FK"
                		LEFT JOIN "Patient" cp ON cp."PatientID" = ct."PatientID_FK"
                		LEFT JOIN "Users" cu ON cu."UserId" = ct."CreatedBy_FK"
                		
                		LEFT JOIN "NotificationTask" nt ON n."id" = nt."NotificationId_FK"
                		LEFT JOIN "Task" t ON t."TaskID" = nt."TaskID_FK"
                		LEFT JOIN "Patient" tp ON tp."PatientID" = t."PatientID_FK"
                	WHERE n."isDeleted" IS FALSE
                		AND n."userId" = user_id_input
                		AND (nvsd."id" IS NOT NULL OR nc."NotificationChatID" IS NOT NULL or nt."NotificationTaskID" IS NOT NULL);
                
                	RETURN notification_count;
                END;
                $$ LANGUAGE plpgsql;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                DROP FUNCTION IF EXISTS "fn_SpGetNotificationAnalysis_Count";
                """);
        }
    }
}
