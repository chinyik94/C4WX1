using C4WX1.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace C4WX1.DbMigrator
{
    public class C4WX1DbContextFactory : IDesignTimeDbContextFactory<THCC_C4WDEVContext>
    {
        public THCC_C4WDEVContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<THCC_C4WDEVContext>();
            optionsBuilder.UseNpgsql(
                configuration.GetConnectionString("DefaultConnection"),
                options => options.UseNodaTime());

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            return new THCC_C4WDEVContext(optionsBuilder.Options);
        }
    }
}
