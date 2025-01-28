using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4WX1.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddSpIsConflictUserTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE OR REPLACE FUNCTION "fn_SpIsConflictUserTask"(
                    user_id_input integer,
                    task_id_input integer,
                    start_date_input timestamp,
                    end_date_input timestamp,
                    recurrence_freq integer,
                    recurrence_days integer,
                    recurrence_interval integer,
                    recurrence_interval_flag integer,
                    recurrence_specific_dates varchar(1000)
                )
                RETURNS boolean
                LANGUAGE plpgsql
                AS $$
                DECLARE
                    check_date timestamp;
                    current_date_val timestamp;
                    start_date_no_time timestamp;
                    start_time_val time;
                    end_time_val time;
                    add_date boolean;
                    task_cursor refcursor;
                    start_check timestamp;
                    end_check timestamp;
                    has_conflict boolean;
                BEGIN
                    -- Initialize variables
                    start_date_no_time := DATE_TRUNC('day', start_date_input);
                    current_date_val := DATE_TRUNC('day', CURRENT_TIMESTAMP);
                    start_time_val := start_date_input::time;
                    end_time_val := end_date_input::time;
                    has_conflict := false;
                
                    -- Create temporary table for task dates
                    CREATE TEMP TABLE IF NOT EXISTS temp_task_dates (
                        task_date timestamp
                    ) ON COMMIT DROP;
                    
                    -- Clear existing data
                    DELETE FROM temp_task_dates;
                
                    -- Handle different recurrence frequencies
                    IF recurrence_freq = 1 THEN
                        -- Single occurrence
                        INSERT INTO temp_task_dates (task_date) 
                        VALUES (start_date_no_time);
                        
                    ELSIF recurrence_freq = 5 THEN
                        -- Specific dates
                        INSERT INTO temp_task_dates (task_date)
                        SELECT value FROM "fn_Split"(recurrence_specific_dates, ',');
                        
                    ELSE
                        -- Other recurrence patterns
                        check_date := start_date_no_time;
                        WHILE check_date <= end_date_input LOOP
                            add_date := false;
                            
                            IF recurrence_freq = 2 THEN
                                -- Daily
                                IF NOT (EXTRACT(DOW FROM check_date) IN (0, 6) AND recurrence_interval = 2) THEN
                                    add_date := true;
                                END IF;
                                
                            ELSIF recurrence_freq = 3 THEN
                                -- Weekly
                                IF "fn_RecurrenceWeeklyDays"(start_date_no_time, check_date, recurrence_interval) AND
                                   ("fn_RecurrenceDayValueFromBits"(check_date) & recurrence_days) > 0 THEN
                                    add_date := true;
                                END IF;
                                
                            ELSIF recurrence_freq = 4 THEN
                                -- Monthly
                                IF ("fn_RecurrenceMonthlyDays"(recurrence_nearest_month_day(start_date_no_time, recurrence_days)::timestamp, 
                                                         check_date, 
                                                         recurrence_interval, 
                                                         recurrence_interval_flag) AND 
                                    EXTRACT(DAY FROM check_date) = recurrence_days AND 
                                    recurrence_interval_flag = 0) OR
                                   (check_date = "fn_RecurrenceMonthDayOccurrence"(check_date, recurrence_days, recurrence_interval) AND 
                                    "fn_RecurrenceMonthlyDays"(start_date_no_time, check_date, recurrence_interval, recurrence_interval_flag) AND 
                                    recurrence_interval_flag > 0) THEN
                                    add_date := true;
                                END IF;
                            END IF;
                            
                            IF add_date THEN
                                INSERT INTO temp_task_dates (task_date) VALUES (check_date);
                            END IF;
                            
                            check_date := check_date + INTERVAL '1 day';
                        END LOOP;
                    END IF;
                
                    -- Check for conflicts
                    FOR check_date IN SELECT task_date FROM temp_task_dates LOOP
                        start_check := (check_date::date || ' ' || start_time_val)::timestamp;
                        end_check := (check_date::date || ' ' || end_time_val)::timestamp;
                        
                        IF EXISTS (
                            SELECT 1 
                            FROM "TaskUserLog" tul 
                            INNER JOIN "Task" t ON t."TaskID" = tul."TaskID_FK" 
                            WHERE t."IsDeleted" = false 
                            AND tul."IsDeleted" = false 
                            AND (task_id_input IS NULL OR task_id_input <> t."TaskID") 
                            AND NOT(start_check >= tul."EndDate" OR end_check <= tul."StartDate")
                        ) THEN
                            has_conflict := true;
                            EXIT;
                        END IF;
                    END LOOP;
                
                    -- Clean up
                    DROP TABLE IF EXISTS temp_task_dates;
                    
                    RETURN has_conflict;
                END;
                $$;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                DROP FUNCTION IF EXISTS "fn_SpIsConflictUserTask";
                """);
        }
    }
}
