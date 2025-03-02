# C4WX1.Database

This is project that mostly stores:
- Entity models
- DB context configuration
- EF Core migrations

Any DB schema changes can be done by executing the SQL script first, then update C# entity models using EF Core Power Tools (existing workflow)

This project is the lowest level among the others, and will be referenced by `C4WX1.API` and `C4WX1.DbMigrator`.