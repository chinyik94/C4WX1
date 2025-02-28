# Migrate MSSQL tables to PostgreSQL

1. Set `C4WX1.API` as startup project
2. Open Package Manager Console, set `C4WX1.Database` as default project
3. Run `Update-Database` command to generate tables in PostgreSQL
4. Open PgAdmin, verify that all tables, triggers, trigger functions and functions are created in the database.