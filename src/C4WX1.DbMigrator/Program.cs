using Microsoft.EntityFrameworkCore;
using Serilog.Events;
using Serilog;
using C4WX1.DbMigrator;
using Microsoft.Extensions.DependencyInjection;
using C4WX1.DbMigrator.DataSeeders;
using C4WX1.Database.Models;
using Microsoft.Extensions.Logging;

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
var serviceProvider = new ServiceCollection()
    .AddLogging(builder => builder.AddSerilog())
    .AddSingleton(factory.CreateDbContext(args))
    .AddTransient(provider => new SysConfigDataSeeder(
        provider.GetRequiredService<THCC_C4WDEVContext>(),
        provider.GetRequiredService<ILogger<SysConfigDataSeeder>>()))
    .BuildServiceProvider();

using var scope = serviceProvider.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<THCC_C4WDEVContext>();
var sysConfigSeeder = scope.ServiceProvider.GetService<SysConfigDataSeeder>();
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

try
{
    Log.Information("Seeding initial data...");
    await sysConfigSeeder.SeedAsync();
}
catch (Exception ex)
{
    await transaction.RollbackAsync();
    Log.Fatal(ex, "Failed to apply initial seed.");
}
finally
{
    Log.CloseAndFlush();
}