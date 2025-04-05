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
                .AddTransient<LanguageDataSeeder>()
                .AddTransient<TypeDataSeeder>()
                .BuildServiceProvider();

            using var scope = serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<THCC_C4WDEVContext>();
            var sysConfigSeeder = scope.ServiceProvider.GetRequiredService<SysConfigDataSeeder>();
            var languageSeeder = scope.ServiceProvider.GetRequiredService<LanguageDataSeeder>();
            var typeSeeder = scope.ServiceProvider.GetRequiredService<TypeDataSeeder>();

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
                await languageSeeder.SeedAsync();
                await typeSeeder.SeedAsync();
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

        public static async Task MigrateAndSeedForTestsAsync(string connectionString)
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging(builder => builder.AddSerilog())
                .AddDbContext<THCC_C4WDEVContext>(options =>
                    options.UseNpgsql(connectionString))
                .AddTransient<LanguageDataSeeder>()
                .AddTransient<TypeDataSeeder>()
                .BuildServiceProvider();
            using var scope = serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<THCC_C4WDEVContext>();
            var languageSeeder = scope.ServiceProvider.GetRequiredService<LanguageDataSeeder>();
            var typeSeeder = scope.ServiceProvider.GetRequiredService<TypeDataSeeder>();
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
            finally
            {
                Log.CloseAndFlush();
            }

            try
            {
                Log.Information("Seeding initial test data...");
                await languageSeeder.SeedAsync();
                await typeSeeder.SeedAsync();
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
