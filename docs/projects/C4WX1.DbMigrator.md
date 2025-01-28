# C4WX1.DbMigrator

This is a console application that is only used for one-time setup when performing migration from MSSQL to PostgreSQL. 

Any DB schema changes can be done by executing the SQL script first, then update C# entity models using EF Core Power Tools in `C4WX1.Database` project. (existing workflow)