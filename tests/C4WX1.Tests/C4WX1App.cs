using C4WX1.Database.Models;
using C4WX1.DbMigrator.Migrators;
using FastEndpoints.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Testcontainers.PostgreSql;

namespace C4WX1.Tests
{
    public class C4WX1App : AppFixture<Program>
    {
        private const string DbName = "C4WX1-test-db";
        private const string RootUsername = "root";
        private const string RootPassword = "root";

        private PostgreSqlContainer _container = null!;

        protected override async ValueTask PreSetupAsync()
        {
            _container = new PostgreSqlBuilder()
                .WithImage("postgres:latest")
                .WithDatabase(DbName)
                .WithUsername(RootUsername)
                .WithPassword(RootPassword)
                .WithCleanUp(true)
                .Build();

            await _container.StartAsync();

            await base.PreSetupAsync();
        }

        protected override async ValueTask SetupAsync()
        {
            await C4WX1DbMigrator.MigrateAndSeedAsync(_container.GetConnectionString());

            await base.SetupAsync();
        }

        protected override IHost ConfigureAppHost(IHostBuilder a)
        {
            a.ConfigureServices((context, services) =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(DbContextOptions<THCC_C4WDEVContext>));
                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                services.AddDbContext<THCC_C4WDEVContext>(options =>
                    options.UseNpgsql(_container.GetConnectionString()));
            });

            var host = a.Build();
            host.Start();
            return host;
        }

        protected override async ValueTask TearDownAsync()
        {
            if (_container != null)
            {
                await _container.StopAsync();
            }

            await base.TearDownAsync();
        }
    }
}
