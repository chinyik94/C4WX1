using C4WX1.Database.Models;
using C4WX1.DbMigrator.DataSeeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.DbMigrator.Migrators
{
    public static class C4WX1DbMigrator
    {
        public static async Task MigrateAndSeedAsync(string connectionString)
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging(builder => builder.AddSerilog())
                .AddDbContext<THCC_C4WDEVContext>(options =>
                    options.UseNpgsql(connectionString))
                .AddTransient<SysConfigDataSeeder>()
                .BuildServiceProvider();

            using var scope = serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<THCC_C4WDEVContext>();
            var sysConfigSeeder = scope.ServiceProvider.GetRequiredService<SysConfigDataSeeder>();

            await using var transaction = await dbContext.Database.BeginTransactionAsync();
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
                throw;
            }

            try
            {
                Log.Information("Seeding initial data...");
                await sysConfigSeeder.SeedAsync();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Failed to apply initial seed.");
                throw;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
