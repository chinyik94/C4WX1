using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4WX1.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddSpPostTaskRecurrenceData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE OR REPLACE FUNCTION "fn_SpPostTaskRecurrenceData"(
                    task_id_param INTEGER,
                    user_id_param INTEGER,
                    start_date_param TIMESTAMP,
                    end_date_param TIMESTAMP,
                    recurrence_frequency_param INTEGER,
                    recurrence_days_param INTEGER,
                    recurrence_interval_param INTEGER,
                    recurrence_interval_flag_param INTEGER,
                    recurrence_specific_dates_param VARCHAR(1000),
                    current_user_id_param INTEGER
                ) RETURNS VOID AS $$
                DECLARE
                    check_date_var TIMESTAMP;
                    current_date_var DATE;
                    start_date_no_time_var DATE;
                    start_time_var TIME;
                    end_time_var TIME;
                    add_date_var BOOLEAN;
                BEGIN
                    -- Convert dates and times
                    start_date_no_time_var := DATE(start_date_param);
                    current_date_var := CURRENT_DATE;
                    start_time_var := start_date_param::TIME;
                    end_time_var := end_date_param::TIME;
                
                    -- Create temporary table
                    CREATE TEMPORARY TABLE task_dates_temp (
                        "TaskDate" TIMESTAMP
                    ) ON COMMIT DROP;
                
                    -- Single occurrence
                    IF recurrence_frequency_param = 1 THEN
                        INSERT INTO task_dates_temp ("TaskDate")
                        VALUES (start_date_no_time_var);
                
                    -- Specific dates
                    ELSIF recurrence_frequency_param = 5 THEN
                        INSERT INTO task_dates_temp ("TaskDate")
                        SELECT value::TIMESTAMP
                        FROM regexp_split_to_table(recurrence_specific_dates_param, ',') AS value;
                
                    -- Other recurrence patterns
                    ELSE
                        check_date_var := start_date_no_time_var;
                        
                        WHILE check_date_var <= end_date_param LOOP
                            add_date_var := FALSE;
                
                            -- Daily (weekday only option)
                            IF recurrence_frequency_param = 2 THEN
                                IF NOT (EXTRACT(DOW FROM check_date_var) IN (0, 6) AND recurrence_interval_param = 2) THEN
                                    add_date_var := TRUE;
                                END IF;
                
                            -- Weekly
                            ELSIF recurrence_frequency_param = 3 THEN
                                -- Note: You'll need to create equivalent functions for these custom functions
                                -- Placeholder logic shown below
                                IF "fn_RecurrenceWeeklyDays"(start_date_no_time_var, check_date_var, recurrence_interval_param) = 1
                                   AND (("fn_RecurrenceDayValueFromBits"(check_date_var) & recurrence_days_param) > 0) THEN
                                    add_date_var := TRUE;
                                END IF;
                
                            -- Monthly
                            ELSIF recurrence_frequency_param = 4 THEN
                                -- Note: You'll need to create equivalent functions for these custom functions
                                -- Placeholder logic shown below
                                IF ("fn_RecurrenceMonthlyDays"("fn_RecurrenceNearestMonthDay"(start_date_no_time_var, recurrence_days_param), 
                                    check_date_var, recurrence_interval_param, recurrence_interval_flag_param) = 1 
                                    AND EXTRACT(DAY FROM check_date_var) = recurrence_days_param 
                                    AND recurrence_interval_flag_param = 0)
                                   OR (check_date_var = "fn_RecurrenceMonthDayOccurrence"(check_date_var, recurrence_days_param, recurrence_interval_param) 
                                       AND "fn_RecurrenceMonthlyDays"(start_date_no_time_var, check_date_var, recurrence_interval_param, recurrence_interval_flag_param) = 1 
                                       AND recurrence_interval_flag_param > 0) THEN
                                    add_date_var := TRUE;
                                END IF;
                            END IF;
                
                            IF add_date_var THEN
                                INSERT INTO task_dates_temp ("TaskDate")
                                VALUES (check_date_var);
                            END IF;
                
                            check_date_var := check_date_var + INTERVAL '1 day';
                        END LOOP;
                    END IF;
                
                    -- Insert into TaskUserLog
                    INSERT INTO "TaskUserLog" (
                        "TaskID_FK",
                        "UserID_FK",
                        "StartDate",
                        "EndDate",
                        "CreatedDate",
                        "CreatedBy_FK",
                        "IsDeleted"
                    )
                    SELECT 
                        task_id_param,
                        user_id_param,
                        ("TaskDate"::DATE || ' ' || start_time_var)::TIMESTAMP,
                        ("TaskDate"::DATE || ' ' || end_time_var)::TIMESTAMP,
                        CURRENT_TIMESTAMP,
                        current_user_id_param,
                        FALSE
                    FROM task_dates_temp t
                    WHERE NOT EXISTS (
                        SELECT 1 
                        FROM "TaskUserLog" 
                        WHERE "IsDeleted" = FALSE 
                        AND "TaskID_FK" = task_id_param 
                        AND "UserID_FK" = user_id_param 
                        AND "StartDate" = (t."TaskDate"::DATE || ' ' || start_time_var)::TIMESTAMP
                    );
                
                    -- Temporary table will be automatically dropped due to ON COMMIT DROP
                END;
                $$ LANGUAGE plpgsql;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                DROP FUNCTION IF EXISTS "fn_SpPostTaskRecurrenceData";
                """);
        }
    }
}
