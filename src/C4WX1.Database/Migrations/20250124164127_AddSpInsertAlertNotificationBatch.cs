using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4WX1.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddSpInsertAlertNotificationBatch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE OR REPLACE FUNCTION "fn_SpInsertAlertNotificationBatch"()
                RETURNS void
                LANGUAGE plpgsql
                AS $$
                BEGIN
                    -- Insert notifications for tasks starting in 5 minutes
                    INSERT INTO "APNSNotification" (
                        "NotificationMessage",
                        "NotificationTitle",
                        "UserID",
                        "IsCritical",
                        "TaskID",
                        "SentStatus"
                    )
                    SELECT 
                        to_char(tu."StartDate", 'HH24:MI:SS') || ' - Reminder for task: ' || c."CodeName",
                        c."CodeName" || ' Reminder',
                        tu."UserID_FK",
                        false,
                        tu."TaskID_FK",
                        false
                    FROM "TaskUserLog" tu
                    INNER JOIN "Task" t ON t."TaskID" = tu."TaskID_FK"
                    INNER JOIN "Code" c ON t."ActionTypeID_FK" = c."CodeId"
                    INNER JOIN "Patient" p ON p."PatientID" = t."PatientID_FK"
                    WHERE CAST(tu."StartDate" AS DATE) = CURRENT_DATE 
                    AND tu."Status" IS NULL
                    AND EXTRACT(EPOCH FROM (tu."StartDate" - CURRENT_TIMESTAMP)) / 60 = 5
                    AND tu."UserID_FK" IN (SELECT "UserID" FROM "RegisteredDevice");
                
                    -- Insert notifications for overdue tasks (5 minutes after end time)
                    INSERT INTO "APNSNotification" (
                        "NotificationMessage",
                        "NotificationTitle",
                        "UserID",
                        "IsCritical",
                        "TaskID",
                        "SentStatus"
                    )
                    SELECT DISTINCT 
                        notification_text,
                        notification_title,
                        user_id,
                        is_critical,
                        task_id,
                        sent_status
                    FROM (
                        -- For Recipients
                        SELECT 
                            CASE 
                                WHEN COALESCE(m."Critical", false) THEN '[CRITICAL] - '
                                ELSE ''
                            END || 
                            to_char(tu."StartDate", 'HH24:MI:SS') || ' to ' || 
                            to_char(tu."EndDate", 'HH24:MI:SS') || ' - Task for ' || 
                            p."Firstname" || ' ' || p."Lastname" || ' not done: ' || 
                            c."CodeName" AS notification_text,
                            CASE 
                                WHEN COALESCE(m."Critical", false) THEN '[CRITICAL] - '
                                ELSE ''
                            END || c."CodeName" || ' not done' AS notification_title,
                            tuser."UserID_FK" AS user_id,
                            COALESCE(m."Critical", false) AS is_critical,
                            tu."TaskID_FK" AS task_id,
                            false AS sent_status
                        FROM "TaskUserLog" tu
                        INNER JOIN "Task" t ON t."TaskID" = tu."TaskID_FK"
                        INNER JOIN "TaskUser" tuser ON tuser."TaskID_FK" = t."TaskID"
                        INNER JOIN "Code" m ON m."CodeId" = t."MedicationID_FK"
                        INNER JOIN "Code" c ON t."ActionTypeID_FK" = c."CodeId"
                        INNER JOIN "Patient" p ON p."PatientID" = t."PatientID_FK"
                        WHERE CAST(tu."StartDate" AS DATE) = CURRENT_DATE
                        AND tu."Status" IS NULL
                        AND "UserType" = 'Recipient'
                        AND EXTRACT(EPOCH FROM (tu."EndDate" - CURRENT_TIMESTAMP)) / 60 = -5
                
                        UNION
                
                        -- For Creators
                        SELECT 
                            CASE 
                                WHEN COALESCE(m."Critical", false) THEN '[CRITICAL] - '
                                ELSE ''
                            END || 
                            to_char(tu."StartDate", 'HH24:MI:SS') || ' to ' || 
                            to_char(tu."EndDate", 'HH24:MI:SS') || ' - Task for ' || 
                            p."Firstname" || ' ' || p."Lastname" || ' not done: ' || 
                            c."CodeName",
                            CASE 
                                WHEN COALESCE(m."Critical", false) THEN '[CRITICAL] - '
                                ELSE ''
                            END || c."CodeName" || ' not done',
                            CASE 
                                WHEN t."CreatedBy_FK" = 0 THEN t."CreatedBy_FK"
                                ELSE t."ModifiedBy_FK"
                            END,
                            COALESCE(m."Critical", false),
                            tu."TaskID_FK",
                            false
                        FROM "TaskUserLog" tu
                        INNER JOIN "Task" t ON t."TaskID" = tu."TaskID_FK"
                        INNER JOIN "Code" m ON m."CodeId" = t."MedicationID_FK"
                        INNER JOIN "Code" c ON t."ActionTypeID_FK" = c."CodeId"
                        INNER JOIN "Patient" p ON p."PatientID" = t."PatientID_FK"
                        WHERE CAST(tu."StartDate" AS DATE) = CURRENT_DATE
                        AND tu."Status" IS NULL
                        AND EXTRACT(EPOCH FROM (tu."EndDate" - CURRENT_TIMESTAMP)) / 60 = -5
                
                        UNION
                
                        -- For Assigned Users
                        SELECT 
                            CASE 
                                WHEN COALESCE(m."Critical", false) THEN '[CRITICAL] - '
                                ELSE ''
                            END || 
                            to_char(tu."StartDate", 'HH24:MI:SS') || ' to ' || 
                            to_char(tu."EndDate", 'HH24:MI:SS') || ' - Task for ' || 
                            p."Firstname" || ' ' || p."Lastname" || ' not done: ' || 
                            c."CodeName",
                            CASE 
                                WHEN COALESCE(m."Critical", false) THEN '[CRITICAL] - '
                                ELSE ''
                            END || c."CodeName" || ' not done',
                            tu."UserID_FK",
                            COALESCE(m."Critical", false),
                            tu."TaskID_FK",
                            false
                        FROM "TaskUserLog" tu
                        INNER JOIN "Task" t ON t."TaskID" = tu."TaskID_FK"
                        INNER JOIN "Code" m ON m."CodeId" = t."MedicationID_FK"
                        INNER JOIN "Code" c ON t."ActionTypeID_FK" = c."CodeId"
                        INNER JOIN "Patient" p ON p."PatientID" = t."PatientID_FK"
                        WHERE CAST(tu."StartDate" AS DATE) = CURRENT_DATE
                        AND tu."Status" IS NULL
                        AND EXTRACT(EPOCH FROM (tu."EndDate" - CURRENT_TIMESTAMP)) / 60 = -5
                    ) subquery
                    WHERE user_id IN (SELECT "UserID" FROM "RegisteredDevice");
                
                    -- Insert notifications for critical overdue tasks (10 minutes after end time)
                    INSERT INTO "APNSNotification" (
                        "NotificationMessage",
                        "NotificationTitle",
                        "UserID",
                        "IsCritical",
                        "TaskID",
                        "SentStatus"
                    )
                    SELECT DISTINCT 
                        notification_text,
                        notification_title,
                        user_id,
                        is_critical,
                        task_id,
                        sent_status
                    FROM (
                        -- For Recipients
                        SELECT 
                            CASE 
                                WHEN COALESCE(m."Critical", false) THEN '[CRITICAL] - '
                                ELSE ''
                            END || 
                            to_char(tu."StartDate", 'HH24:MI:SS') || ' to ' || 
                            to_char(tu."EndDate", 'HH24:MI:SS') || ' - Task for ' || 
                            p."Firstname" || ' ' || p."Lastname" || ' not done: ' || 
                            c."CodeName" AS notification_text,
                            CASE 
                                WHEN COALESCE(m."Critical", false) THEN '[CRITICAL] - '
                                ELSE ''
                            END || c."CodeName" || ' not done' AS notification_title,
                            tuser."UserID_FK" AS user_id,
                            COALESCE(m."Critical", false) AS is_critical,
                            tu."TaskID_FK" AS task_id,
                            false AS sent_status
                        FROM "TaskUserLog" tu
                        INNER JOIN "Task" t ON t."TaskID" = tu."TaskID_FK"
                        INNER JOIN "TaskUser" tuser ON tuser."TaskID_FK" = t."TaskID"
                        INNER JOIN "Code" m ON m."CodeId" = t."MedicationID_FK"
                        INNER JOIN "Code" c ON t."ActionTypeID_FK" = c."CodeId"
                        INNER JOIN "Patient" p ON p."PatientID" = t."PatientID_FK"
                        WHERE CAST(tu."StartDate" AS DATE) = CURRENT_DATE
                        AND tu."Status" IS NULL
                        AND COALESCE(m."Critical", false) = true
                        AND "UserType" = 'Recipient'
                        AND EXTRACT(EPOCH FROM (tu."EndDate" - CURRENT_TIMESTAMP)) / 60 = -10
                
                        UNION
                
                        -- For Creators
                        SELECT 
                            CASE 
                                WHEN COALESCE(m."Critical", false) THEN '[CRITICAL] - '
                                ELSE ''
                            END || 
                            to_char(tu."StartDate", 'HH24:MI:SS') || ' to ' || 
                            to_char(tu."EndDate", 'HH24:MI:SS') || ' - Task for ' || 
                            p."Firstname" || ' ' || p."Lastname" || ' not done: ' || 
                            c."CodeName",
                            CASE 
                                WHEN COALESCE(m."Critical", false) THEN '[CRITICAL] - '
                                ELSE ''
                            END || c."CodeName" || ' not done',
                            CASE 
                                WHEN t."CreatedBy_FK" = 0 THEN t."CreatedBy_FK"
                                ELSE t."ModifiedBy_FK"
                            END,
                            COALESCE(m."Critical", false),
                            tu."TaskID_FK",
                            false
                        FROM "TaskUserLog" tu
                        INNER JOIN "Task" t ON t."TaskID" = tu."TaskID_FK"
                        INNER JOIN "Code" m ON m."CodeId" = t."MedicationID_FK"
                        INNER JOIN "Code" c ON t."ActionTypeID_FK" = c."CodeId"
                        INNER JOIN "Patient" p ON p."PatientID" = t."PatientID_FK"
                        WHERE CAST(tu."StartDate" AS DATE) = CURRENT_DATE
                        AND tu."Status" IS NULL
                        AND COALESCE(m."Critical", false) = true
                        AND EXTRACT(EPOCH FROM (tu."EndDate" - CURRENT_TIMESTAMP)) / 60 = -10
                
                        UNION
                
                        -- For Assigned Users
                        SELECT 
                            CASE 
                                WHEN COALESCE(m."Critical", false) THEN '[CRITICAL] - '
                                ELSE ''
                            END || 
                            to_char(tu."StartDate", 'HH24:MI:SS') || ' to ' || 
                            to_char(tu."EndDate", 'HH24:MI:SS') || ' - Task for ' || 
                            p."Firstname" || ' ' || p."Lastname" || ' not done: ' || 
                            c."CodeName",
                            CASE 
                                WHEN COALESCE(m."Critical", false) THEN '[CRITICAL] - '
                                ELSE ''
                            END || c."CodeName" || ' not done',
                            tu."UserID_FK",
                            COALESCE(m."Critical", false),
                            tu."TaskID_FK",
                            false
                        FROM "TaskUserLog" tu
                        INNER JOIN "Task" t ON t."TaskID" = tu."TaskID_FK"
                        INNER JOIN "Code" m ON m."CodeId" = t."MedicationID_FK"
                        INNER JOIN "Code" c ON t."ActionTypeID_FK" = c."CodeId"
                        INNER JOIN "Patient" p ON p."PatientID" = t."PatientID_FK"
                        WHERE CAST(tu."StartDate" AS DATE) = CURRENT_DATE
                        AND tu."Status" IS NULL
                        AND COALESCE(m."Critical", false) = true
                        AND EXTRACT(EPOCH FROM (tu."EndDate" - CURRENT_TIMESTAMP)) / 60 = -10
                    ) subquery
                    WHERE user_id IN (SELECT "UserID" FROM "RegisteredDevice");
                END;
                $$;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                DROP FUNCTION IF EXISTS "fn_SpInsertAlertNotificationBatch";
                """);
        }
    }
}
