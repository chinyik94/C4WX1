using Microsoft.EntityFrameworkCore;
using Serilog.Events;
using Serilog;
using Microsoft.Extensions.Configuration;
using C4WX1.DbMigrator.Migrators;

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

try
{
    Log.Information("Starting database migration...");

    var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .Build();

    var connectionString = configuration.GetConnectionString("Default");

    if (!string.IsNullOrWhiteSpace(connectionString))
    {
        await C4WX1DbMigrator.MigrateAndSeedAsync(connectionString);
        Log.Information("Database migration completed successfully.");
    }
    else
    {
        Log.Warning("Database migration did not complete due to invalid connection string.");
    }

}
catch (Exception ex)
{
    Log.Fatal(ex, "Failed to apply migrations.");
}
finally
{
    Log.CloseAndFlush();
}