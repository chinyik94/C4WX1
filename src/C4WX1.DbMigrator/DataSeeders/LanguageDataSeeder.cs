using C4WX1.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace C4WX1.DbMigrator.DataSeeders
{
    public class LanguageDataSeeder(
        THCC_C4WDEVContext dbContext,
        ILogger<LanguageDataSeeder> logger)
    {
        public async Task<int> SeedAsync()
        {
            var numberOfRecords = 0;
            if (await dbContext.Language.AnyAsync())
            {
                logger.LogInformation("Language is already seeded.");
                return numberOfRecords;
            }

            logger.LogInformation("Start seeding Language...");
            dbContext.Language.Add(new()
            {
                LanguageId = 1,
                Name = "en-US",
                FullName = "English"
            });
            dbContext.Language.Add(new()
            {
                LanguageId = 2,
                Name = "pt-BR",
                FullName = "Portuguese (Brazil)"
            });

            numberOfRecords = await dbContext.SaveChangesAsync();
            return numberOfRecords;
        }
    }
}
