using C4WX1.Database.Models;
using CsvHelper.Configuration;
using CsvHelper;
using Microsoft.Extensions.Logging;
using System.Globalization;
using Task = System.Threading.Tasks.Task;
using Microsoft.EntityFrameworkCore;

namespace C4WX1.DbMigrator.DataSeeders
{
    public class TypeDataSeeder(
        THCC_C4WDEVContext dbContext,
        ILogger<TypeDataSeeder> logger)
    {
        public async Task SeedAsync()
        {
            if (await dbContext.Types.AnyAsync())
            {
                logger.LogInformation("Type is already seeded.");
                return;
            }

            var csvFilePath = Path.Combine(Directory.GetCurrentDirectory(), "SeedSources", "Type.csv");
            if (!File.Exists(csvFilePath))
            {
                logger.LogError("Type data file cannot be found.");
                return;
            }

            logger.LogInformation("Start seeding Type...");
            using var reader = new StreamReader(csvFilePath);
            using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                TrimOptions = TrimOptions.Trim,
                MissingFieldFound = null,
            });
            csv.Context.TypeConverterOptionsCache.GetOptions<string>().NullValues.Add(string.Empty);

            var types = csv.GetRecords<Types>()
                .Select(x => new Types
                {
                    code = x.code,
                    codeValue = x.codeValue,
                    parentCode = x.parentCode,
                    ordering = x.ordering,
                    created = x.created,
                    updated = x.updated
                });
            await dbContext.Types.AddRangeAsync(types);
            await dbContext.SaveChangesAsync();
        }
    }
}
