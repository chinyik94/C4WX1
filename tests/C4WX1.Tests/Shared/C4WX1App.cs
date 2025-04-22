using C4WX1.API.Extensions;
using C4WX1.Database.Models;
using C4WX1.DbMigrator.DataSeeders;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Testcontainers.PostgreSql;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.Tests.Shared;

public class C4WX1App : AppFixture<Program>
{
    public int SysConfigCount { get; private set; } = 0;
    public int LanguageCount { get; private set; } = 0;
    public int TypeCount { get; private set; } = 0;

    private const string DbName = "C4WX1-test-db";
    private const string RootUsername = "root";
    private const string RootPassword = "root";

    private IServiceScopeFactory _scopeFactory = null!;

    protected PostgreSqlContainer _container = null!;

    public THCC_C4WDEVContext CreateDbContext()
    {
        var scope = _scopeFactory.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<THCC_C4WDEVContext>();
        return dbContext;
    }

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
            services.AddTransient<SysConfigDataSeeder>()
                .AddTransient<LanguageDataSeeder>()
                .AddTransient<TypeDataSeeder>()
                .AddAppServices();
        });
        a.ConfigureAppConfiguration((context, config) =>
        {
            config.AddInMemoryCollection(
            [
                new KeyValuePair<string, string?>("ConnectionStrings:Default",
                    _container.GetConnectionString())
            ]);
        });

        var host = a.Build();
        host.Start();
        _scopeFactory = host.Services.GetRequiredService<IServiceScopeFactory>();
        using var scope = _scopeFactory.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<THCC_C4WDEVContext>();
        dbContext.Database.Migrate();
        SeedAsync(scope).GetAwaiter().GetResult();
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

    private async Task SeedAsync(IServiceScope scope)
    {
        var sysConfigSeeder = scope.ServiceProvider.GetRequiredService<SysConfigDataSeeder>();
        SysConfigCount = await sysConfigSeeder.SeedAsync();

        var languageSeeder = scope.ServiceProvider.GetRequiredService<LanguageDataSeeder>();
        LanguageCount = await languageSeeder.SeedAsync();

        var typeSeeder = scope.ServiceProvider.GetRequiredService<TypeDataSeeder>();
        TypeCount = await typeSeeder.SeedAsync();
    }
}
