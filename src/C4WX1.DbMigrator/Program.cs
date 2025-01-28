using Microsoft.EntityFrameworkCore;
using Serilog.Events;
using Serilog;
using C4WX1.DbMigrator;
using Npgsql;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File(
        "logs/C4WX1-dbMigrator-.txt",
        rollingInterval: RollingInterval.Day,
        rollOnFileSizeLimit: true,
        retainedFileTimeLimit: TimeSpan.FromDays(30),
        restrictedToMinimumLevel: LogEventLevel.Information)
    .Enrich.FromLogContext()
    .CreateLogger();

var factory = new C4WX1DbContextFactory();
try
{
    var connectionString = factory.CreateDbContext(args).Database.GetConnectionString();
    var builder = new NpgsqlConnectionStringBuilder(connectionString);
    var databaseName = builder.Database;
    builder.Database = "postgres";
    using var adminConnection = new NpgsqlConnection(builder.ConnectionString);

    adminConnection.Open();
    Log.Information($"Checking if database '{databaseName}' exists...");
    var checkDbCmd = new NpgsqlCommand($"SELECT 1 FROM pg_database WHERE datname = '{databaseName}';", adminConnection);
    var exists = checkDbCmd.ExecuteScalar();

    if (exists == null)
    {
        Log.Information($"Database '{databaseName}' does not exist. Creating...");
        var createDbCmd = new NpgsqlCommand($"CREATE DATABASE \"{databaseName}\" WITH ENCODING 'UTF8';", adminConnection);
        createDbCmd.ExecuteNonQuery();
        Log.Information($"Database '{databaseName}' created successfully.");
    }
    else
    {
        Log.Information($"Database '{databaseName}' already exists.");
    }
}
catch (Exception ex)
{
    Log.Fatal(ex, "Failed to create database.");
    Log.CloseAndFlush();
    Environment.Exit(1);
}

using var dbContext = factory.CreateDbContext(args);
var transaction = await dbContext.Database.BeginTransactionAsync();
try
{
    Log.Information("Applying migrations...");
    await dbContext.Database.MigrateAsync();
    await transaction.CommitAsync();
    Log.Information("Migrations applied successfully.");
}
catch (Exception ex)
{
    await transaction.RollbackAsync();
    Log.Fatal(ex, "Failed to apply migrations.");
}
finally
{
    Log.CloseAndFlush();
}