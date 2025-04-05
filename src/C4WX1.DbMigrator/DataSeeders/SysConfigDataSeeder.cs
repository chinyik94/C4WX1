using C4WX1.Database.Models;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Globalization;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.DbMigrator.DataSeeders
{
    public class SysConfigDataSeeder(
        THCC_C4WDEVContext dbContext,
        ILogger<SysConfigDataSeeder> logger)
    {
        public async Task SeedAsync()
        {
            if (await dbContext.SysConfig.AnyAsync())
            {
                logger.LogInformation("SysConfig is already seeded.");
                return;
            }

            var csvFilePath = Path.Combine(Directory.GetCurrentDirectory(), "SeedSources", "SysConfig.csv");
            if (!File.Exists(csvFilePath))
            {
                logger.LogError("SysConfig data file cannot be found.");
                return;
            }

            logger.LogInformation("Start seeding SysConfig...");
            using var reader = new StreamReader(csvFilePath);
            using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                TrimOptions = TrimOptions.Trim,
                MissingFieldFound = null,
            });

            await foreach (var record in csv.GetRecordsAsync<SysConfig>())
            {
                dbContext.SysConfig.Add(record);
            }

            await dbContext.SaveChangesAsync();
        }
    }
}
