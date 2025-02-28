# POC C4WX1 Web Services

This is a POC to demonstrate how we can separate Data Access Layer from C4WX1 completely, by making HTTP calls from C4WX1 Web App instead of accessing the entities directly.

This Web Service aims to resolve the following:
- Support for PostgreSQL DB
- Improve query time by using newer EF Core instead of EF 6 (it is already out-of-support)
- Using C# instead of VB since it is already out-of-support
- Reduce CARES workload by separating DB calls

## Technologies Used
- .NET 9
- EF Core with Npgsql
- FastEndpoints
- Serilog
- Dapper