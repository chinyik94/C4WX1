using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4WX1.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddSpGetNotificationAnalysis_List : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE OR REPLACE FUNCTION "fn_SpGetNotificationAnalysis_List"(
                    user_id_param integer,
                    page_index_param integer,
                    page_size_param integer,
                    order_by_param varchar(150)
                )
                RETURNS TABLE (
                    "NotificationId" integer,
                    "UserId" integer,
                    "NotificationTypeCode" varchar,
                    "IsRead" boolean,
                    "CreatedDate" timestamp,
                    "PatientName" TEXT,
                    "PatientId" integer,
                    "VitalSignTypeId" integer,
                    "VitalSignTypeName" varchar,
                    "VitalSignId" integer,
                    "VitalSignValue" NUMERIC(18,2),
                    "VitalSignScore" SMALLINT,
                    "Frequency" bigint,
                    "ChatId" integer,
                    "ChatComment" text,
                    "ChatAttachment" varchar,
                    "ChatAttachment_Physical" varchar,
                    "ChatCreatedById" integer,
                    "ChatCreatedByName" TEXT
                ) AS $$
                BEGIN
                    RETURN QUERY
                    WITH base_query AS (
                        SELECT 
                            n."id" AS "r_NotificationId",
                            n."userId" AS "r_userId",
                            n."notificationTypeCode" AS "r_notificationTypeCode",
                            n."isRead" AS "r_isRead",
                            n."createdDate" AS "r_createdDate",
                            CASE 
                                WHEN vp."PatientID" IS NOT NULL THEN vp."Firstname" || ' ' || vp."Lastname"
                                WHEN cp."PatientID" IS NOT NULL THEN cp."Firstname" || ' ' || cp."Lastname"
                                ELSE tp."Firstname" || ' ' || tp."Lastname"
                            END AS "r_PatientName",
                            CASE 
                                WHEN vp."PatientID" IS NOT NULL THEN vp."PatientID"
                                WHEN cp."PatientID" IS NOT NULL THEN cp."PatientID"
                                ELSE tp."PatientID"
                            END AS "r_PatientId",
                            vst."id" AS "r_VitalSignTypeId",
                            vst."name" AS "r_VitalSignTypeName",
                            vs."id" AS "r_VitalSignId",
                            vsd."detailValue" AS "r_VitalSignValue",
                            public."fn_VitalSignScore"(vp."PatientID", vst."id", vsd."detailValue") AS "r_VitalSignScore",
                            COUNT(vst."name") OVER (
                                PARTITION BY 
                                    vs."patientId", vst."name", 
                                    EXTRACT(DAY FROM n."createdDate"),
                                    EXTRACT(MONTH FROM n."createdDate"),
                                    EXTRACT(YEAR FROM n."createdDate")
                            ) AS "r_Frequency",
                            ct."ChatID" AS "r_ChatID",
                            ct."Comment" AS "r_ChatComment",
                            ct."Attachment" AS "r_ChatAttachment",
                            ct."Attachment_Physical" AS "r_ChatAttachment_Physical",
                            ct."CreatedBy_FK" AS "r_ChatCreatedById",
                            cu."Firstname" || ' ' || cu."LastActivityDate" AS "r_ChatCreatedByName"
                        FROM "Notifications" n
                            LEFT JOIN "NotificationVitalSignDetails" nvsd ON n."id" = nvsd."notificationId"
                            LEFT JOIN "VitalSignDetails" vsd ON nvsd."VitalSignDetailId" = vsd."id"
                            LEFT JOIN "VitalSigns" vs ON vs."id" = vsd."vitalSignId"
                            LEFT JOIN "Patient" vp ON vp."PatientID" = vs."patientId"
                            LEFT JOIN "VitalSignTypes" vst ON vst."id" = vsd."vitalSignTypeId"
                            LEFT JOIN "NotificationChat" nc ON n."id" = nc."NotificationId_FK"
                            LEFT JOIN "Chat" ct ON ct."ChatID" = nc."ChatID_FK"
                            LEFT JOIN "Patient" cp ON cp."PatientID" = ct."ParentID_FK"
                            LEFT JOIN "Users" cu ON cu."UserId" = ct."CreatedBy_FK"
                            LEFT JOIN "NotificationTask" nt ON n."id" = nt."NotificationId_FK"
                            LEFT JOIN "Task" t ON t."TaskID" = nt."TaskID_FK"
                            LEFT JOIN "Patient" tp ON tp."PatientID" = t."PatientID_FK"
                        WHERE n."isDeleted" = false 
                            AND n."userId" = user_id_param
                            AND (nvsd."id" IS NOT NULL OR nc."NotificationChatID" IS NOT NULL OR nt."NotificationTaskID" IS NOT NULL)
                    )
                    SELECT 
                	    "r_NotificationId",
                	    "r_userId",
                	    "r_notificationTypeCode",
                	    "r_isRead",
                	    "r_createdDate",
                	    "r_PatientName",
                	    "r_PatientId",
                	    "r_VitalSignTypeId",
                	    "r_VitalSignTypeName",
                	    "r_VitalSignId",
                	    "r_VitalSignValue",
                	    "r_VitalSignScore",
                	    "r_Frequency",
                	    "r_ChatID",
                	    "r_ChatComment",
                	    "r_ChatAttachment",
                	    "r_ChatAttachment_Physical",
                	    "r_ChatCreatedById",
                	    "r_ChatCreatedByName"
                    FROM (
                        SELECT 
                            *,
                            ROW_NUMBER() OVER (
                                ORDER BY
                                    CASE WHEN order_by_param ILIKE '%CreatedDate%asc%'
                                        THEN "CreatedDate"::text
                                    WHEN order_by_param ILIKE '%PatientName%asc%'
                                        THEN "r_PatientName"
                                    ELSE NULL
                                    END ASC NULLS LAST,
                                    CASE WHEN order_by_param ILIKE '%CreatedDate%desc%'
                                        THEN "CreatedDate"::text
                                    WHEN order_by_param ILIKE '%PatientName%desc%'
                                        THEN "r_PatientName"
                                    ELSE NULL
                                    END DESC NULLS LAST
                            ) AS row_num
                        FROM base_query
                    ) ranked
                    WHERE row_num BETWEEN ((page_index_param - 1) * page_size_param + 1)
                        AND (page_index_param - 1) * page_size_param + page_size_param;
                END;
                $$ LANGUAGE plpgsql;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                DROP FUNCTION IF EXISTS "fn_SpGetNotificationAnalysis_List";
                """);
        }
    }
}
