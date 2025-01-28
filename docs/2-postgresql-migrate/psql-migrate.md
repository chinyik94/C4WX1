# Migrate MSSQL tables to PostgreSQL

1. Open the solution, right click on `C4WX1.DbMigrator` > "Set as startup project"
2. Make sure the connection string in `appsettings.json` matches with the db properties that are created in [PostgreSQL DB Setup Steps](../1-postgresql-setup/psql-setup.md)
3. Run `C4WX1.DbMigrator`, it is a console application. Wait for the DbMigrator to complete the process.
4. Open PgAdmin, verify that all tables, triggers, trigger functions and functions are created in the database.