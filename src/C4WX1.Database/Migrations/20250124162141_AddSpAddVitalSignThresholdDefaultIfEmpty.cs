using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4WX1.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddSpAddVitalSignThresholdDefaultIfEmpty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE OR REPLACE FUNCTION "fn_SpAddVitalSignThresholdDefaultIfEmpty"(
                    patient_id_param INTEGER
                )
                RETURNS VOID
                LANGUAGE plpgsql
                AS $$
                BEGIN
                    -- Check if patient exists
                    IF NOT EXISTS (
                        SELECT 1 
                        FROM "Patient" 
                        WHERE "PatientID" = patient_id_param
                    ) THEN
                        RETURN;
                    END IF;
                
                    -- Insert missing thresholds and relationships in one transaction
                    WITH missing_thresholds AS (
                        SELECT 
                            vstt."VitalSignTypeID_FK",
                            vstt."ews_min_1", vstt."ews_max_1",
                            vstt."ews_min_2", vstt."ews_max_2",
                            vstt."ews_min_3", vstt."ews_max_3",
                            vstt."ews_min_4", vstt."ews_max_4",
                            vstt."ews_min_5", vstt."ews_max_5",
                            vstt."ews_min_6", vstt."ews_max_6",
                            vstt."ews_min_7", vstt."ews_max_7"
                        FROM "VitalSignTypeThreshold" vstt
                        WHERE NOT EXISTS (
                            SELECT 1 
                            FROM "VitalSignRelationships" vsr
                            WHERE vsr."patientId" = patient_id_param
                            AND vsr."vitalSignTypeId" = vstt."VitalSignTypeID_FK"
                        )
                    ),
                    inserted_thresholds AS (
                        INSERT INTO "Thresholds" (
                            "minValue", "maxValue", "isDeleted", "createdDate",
                            "ews_min_1", "ews_max_1",
                            "ews_min_2", "ews_max_2",
                            "ews_min_3", "ews_max_3",
                            "ews_min_4", "ews_max_4",
                            "ews_min_5", "ews_max_5",
                            "ews_min_6", "ews_max_6",
                            "ews_min_7", "ews_max_7"
                        )
                        SELECT 
                            0, 0, FALSE, CURRENT_TIMESTAMP,
                            mt."ews_min_1", mt."ews_max_1",
                            mt."ews_min_2", mt."ews_max_2",
                            mt."ews_min_3", mt."ews_max_3",
                            mt."ews_min_4", mt."ews_max_4",
                            mt."ews_min_5", mt."ews_max_5",
                            mt."ews_min_6", mt."ews_max_6",
                            mt."ews_min_7", mt."ews_max_7"
                        FROM missing_thresholds mt
                        RETURNING "id", "VitalSignTypeID_FK"
                    )
                    INSERT INTO "VitalSignRelationships" (
                        "vitalSignTypeId",
                        "patientId",
                        "thresholdId"
                    )
                    SELECT 
                        mt."VitalSignTypeID_FK",
                        patient_id_param,
                        it."id"
                    FROM missing_thresholds mt
                    JOIN inserted_thresholds it ON it."VitalSignTypeID_FK" = mt."VitalSignTypeID_FK";
                
                END;
                $$;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                DROP FUNCTION IF EXISTS "fn_SpAddVitalSignThresholdDefaultIfEmpty";
                """);
        }
    }
}
