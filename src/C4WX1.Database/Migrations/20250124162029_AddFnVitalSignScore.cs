using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4WX1.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddFnVitalSignScore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE OR REPLACE FUNCTION "fn_VitalSignScore"(
                    patient_id INT,
                    vitalsign_type_id INT,
                    value NUMERIC(18, 2)
                )
                RETURNS SMALLINT AS $$
                DECLARE
                    n_ews_min_1 NUMERIC(18, 2);
                    n_ews_max_1 NUMERIC(18, 2);
                    n_ews_min_2 NUMERIC(18, 2);
                    n_ews_max_2 NUMERIC(18, 2);
                    n_ews_min_3 NUMERIC(18, 2);
                    n_ews_max_3 NUMERIC(18, 2);
                    n_ews_min_4 NUMERIC(18, 2);
                    n_ews_max_4 NUMERIC(18, 2);
                    n_ews_min_5 NUMERIC(18, 2);
                    n_ews_max_5 NUMERIC(18, 2);
                    n_ews_min_6 NUMERIC(18, 2);
                    n_ews_max_6 NUMERIC(18, 2);
                    n_ews_min_7 NUMERIC(18, 2);
                    n_ews_max_7 NUMERIC(18, 2);
                BEGIN
                    -- Fetch the threshold ranges for the patient and vital sign type
                    SELECT "ews_min_1", "ews_max_1",
                           "ews_min_2", "ews_max_2",
                           "ews_min_3", "ews_max_3",
                           "ews_min_4", "ews_max_4",
                           "ews_min_5", "ews_max_5",
                           "ews_min_6", "ews_max_6",
                           "ews_min_7", "ews_max_7"
                    INTO n_ews_min_1, n_ews_max_1,
                         n_ews_min_2, n_ews_max_2,
                         n_ews_min_3, n_ews_max_3,
                         n_ews_min_4, n_ews_max_4,
                         n_ews_min_5, n_ews_max_5,
                         n_ews_min_6, n_ews_max_6,
                         n_ews_min_7, n_ews_max_7
                    FROM "Thresholds" t
                    INNER JOIN "VitalSignRelationships" vsr ON t."id" = vsr."thresholdId"
                    WHERE vsr."patientId" = patient_id AND vsr."vitalSignTypeId" = vitalsign_type_id
                    LIMIT 1;
                
                    -- Evaluate the value against thresholds
                    IF value BETWEEN n_ews_min_1 AND n_ews_max_1 THEN
                        RETURN -3;
                    ELSIF value BETWEEN n_ews_min_2 AND n_ews_max_2 THEN
                        RETURN -2;
                    ELSIF value BETWEEN n_ews_min_3 AND n_ews_max_3 THEN
                        RETURN -1;
                    ELSIF value BETWEEN n_ews_min_4 AND n_ews_max_4 THEN
                        RETURN 0;
                    ELSIF value BETWEEN n_ews_min_5 AND n_ews_max_5 THEN
                        RETURN 1;
                    ELSIF value BETWEEN n_ews_min_6 AND n_ews_max_6 THEN
                        RETURN 2;
                    ELSIF value BETWEEN n_ews_min_7 AND n_ews_max_7 THEN
                        RETURN 3;
                    ELSE
                        RETURN NULL;
                    END IF;
                END;
                $$ LANGUAGE plpgsql;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                DROP FUNCTION IF EXISTS "fn_VitalSignScore";
                """);
        }
    }
}
