using C4WX1.API.Features.SysConfig.Constants;
using C4WX1.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace C4WX1.API.Features.SysConfig.Repository
{
    public class SysConfigRepository(THCC_C4WDEVContext dbContext) : ISysConfigRepository
    {
        public async Task<string> GenerateNewBillingProposalNumberAsync(int userId, CancellationToken ct = default)
        {
            var index = 1;
            var currentYear = DateTime.Now.Year;
            var newProposalNumber = string.Empty;
            var entity = await dbContext.SysConfig
                .Where(x => x.ConfigName == SysConfigNames.BillingProposalRunningNo)
                .FirstOrDefaultAsync(ct) 
                ?? throw new Exception("Proposal Number SysConfig not found");
            var currentProposalNumber = entity.ConfigValue;

            if (!string.IsNullOrWhiteSpace(currentProposalNumber)
                && currentProposalNumber.Length == 0
                && int.TryParse(currentProposalNumber[..4], out int proposalYear)
                && proposalYear == currentYear)
            {
                index = int.TryParse(currentProposalNumber[4..], out int value)
                    ? value += 1
                    : 1;
            }
            newProposalNumber = $"{currentYear}{index:000000}";

            entity.ConfigValue = newProposalNumber;
            entity.ModifiedBy_FK = userId;
            entity.ModifiedDate = DateTime.Now;
            await dbContext.SaveChangesAsync(ct);

            return newProposalNumber;
        }
    }
}
