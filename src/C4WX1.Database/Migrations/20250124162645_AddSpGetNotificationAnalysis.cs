using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4WX1.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddSpGetNotificationAnalysis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE OR REPLACE FUNCTION "fn_SpGetNotificationAnalysis"(
                    user_id_param INTEGER
                )
                RETURNS TABLE (
                    "id" INTEGER,
                    "userId" INTEGER,
                    "vitalSignTypeId" INTEGER,
                    "name" VARCHAR,
                    "patientId" INTEGER,
                    "patientName" TEXT,
                    "vitalSignId" INTEGER,
                    "detailValue" NUMERIC(18,2),
                    "Frequency" BIGINT,
                    "notificationTypeCode" VARCHAR,
                    "isRead" BOOLEAN,
                    "isDeleted" BOOLEAN,
                    "createdDate" TIMESTAMP
                )
                LANGUAGE plpgsql
                AS $$
                BEGIN
                    RETURN QUERY
                    SELECT 
                        nd."id",
                        n."userId",
                        vsd."vitalSignTypeId",
                        vst."name",
                        p."PatientID" AS "patientId",
                        p."Firstname" || ' ' || p."Lastname" AS "patientName",
                        vsd."vitalSignId",
                        vsd."detailValue",
                        COUNT(vst."name") OVER (
                            PARTITION BY 
                                vs."patientId",
                                vst."name",
                                EXTRACT(DAY FROM n."createdDate"),
                                EXTRACT(MONTH FROM n."createdDate"),
                                EXTRACT(YEAR FROM n."createdDate")
                        ) AS "Frequency",
                        n."notificationTypeCode",
                        n."isRead",
                        n."isDeleted",
                        n."createdDate"
                    FROM "VitalSignDetails" vsd
                        INNER JOIN "NotificationVitalSignDetails" nd ON nd."VitalSignDetailId" = vsd."id"
                        LEFT JOIN "VitalSignTypes" vst ON vst."id" = vsd."vitalSignTypeId"
                        LEFT JOIN "VitalSigns" vs ON vs."id" = vsd."vitalSignId"
                        LEFT JOIN "Patient" p ON p."PatientID" = vs."patientId"
                        LEFT JOIN "Notifications" n ON n."id" = nd."notificationId"
                    WHERE NOT n."isDeleted" 
                        AND n."userId" = user_id_param
                    ORDER BY "Frequency" DESC, n."createdDate" DESC, vs."patientId", vst."name";
                END;
                $$;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                DROP FUNCTION IF EXISTS "fn_SpGetNotificationAnalysis";
                """);
        }
    }
}
