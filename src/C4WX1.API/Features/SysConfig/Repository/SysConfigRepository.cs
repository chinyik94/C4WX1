using C4WX1.API.Features.Security;
using C4WX1.API.Features.SysConfig.Constants;

namespace C4WX1.API.Features.SysConfig.Repository;

public class SysConfigRepository(
    THCC_C4WDEVContext dbContext, 
    ISecurityService securityService) 
    : ISysConfigRepository
{
    public async Task<string> GenerateNewBillingInvoiceNumberAsync(
        int userId, 
        CancellationToken ct = default)
    {
        var index = 1;
        var currentYear = DateTime.Now.Year;
        var newInvoiceNumber = string.Empty;
        var entity = await dbContext.SysConfig
            .Where(x => x.ConfigName == SysConfigNames.BillingInvoiceRunningNo)
            .FirstOrDefaultAsync(ct)
            ?? throw new Exception($"{SysConfigNames.BillingInvoiceRunningNo} SysConfig not found");
        var currentInvoiceNumber = entity.ConfigValue;

        if (!string.IsNullOrWhiteSpace(currentInvoiceNumber)
            && currentInvoiceNumber.Length == 0
            && int.TryParse(currentInvoiceNumber[..4], out int proposalYear)
            && proposalYear == currentYear)
        {
            index = int.TryParse(currentInvoiceNumber[4..], out int value)
                ? value += 1
                : 1;
        }
        newInvoiceNumber = $"{currentYear}{index:000000}";

        entity.ConfigValue = newInvoiceNumber;
        entity.ModifiedBy_FK = userId;
        entity.ModifiedDate = DateTime.Now;
        await dbContext.SaveChangesAsync(ct);

        return newInvoiceNumber;
    }

    public async Task<string> GenerateNewBillingProposalNumberAsync(
        int userId, 
        CancellationToken ct = default)
    {
        var index = 1;
        var currentYear = DateTime.Now.Year;
        var newProposalNumber = string.Empty;
        var entity = await dbContext.SysConfig
            .Where(x => x.ConfigName == SysConfigNames.BillingProposalRunningNo)
            .FirstOrDefaultAsync(ct) 
            ?? throw new Exception($"{SysConfigNames.BillingProposalRunningNo} SysConfig not found");
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

    public async Task<string> GenerateNewReceiptNumberAsync(
        int userId, 
        CancellationToken ct = default)
    {
        var index = 1;
        var currentYear = DateTime.Now.Year;
        var newReceiptNumber = string.Empty;
        var entity = await dbContext.SysConfig
            .Where(x => x.ConfigName == SysConfigNames.ReceiptRunningNo)
            .FirstOrDefaultAsync(ct)
            ?? throw new Exception($"{SysConfigNames.ReceiptRunningNo} SysConfig not found");
        var currentReceiptNumber = entity.ConfigValue;

        if (!string.IsNullOrWhiteSpace(currentReceiptNumber)
            && currentReceiptNumber.Length == 0
            && int.TryParse(currentReceiptNumber[..4], out int proposalYear)
            && proposalYear == currentYear)
        {
            index = int.TryParse(currentReceiptNumber[4..], out int value)
                ? value += 1
                : 1;
        }
        newReceiptNumber = $"{currentYear}{index:000000}";

        entity.ConfigValue = newReceiptNumber;
        entity.ModifiedBy_FK = userId;
        entity.ModifiedDate = DateTime.Now;
        await dbContext.SaveChangesAsync(ct);

        return newReceiptNumber;
    }

    public async Task<string> GetEnterpriseAbbrAsync(CancellationToken ct = default)
    {
        var enterpriseAbbrSysConfig = await dbContext.SysConfig
            .Where(x => x.ConfigName == SysConfigNames.EnterpriseAbbr)
            .FirstOrDefaultAsync(ct);
        var enterpriseAbbr = enterpriseAbbrSysConfig?.ConfigValue;
        if (string.IsNullOrWhiteSpace(enterpriseAbbr))
        {
            throw new Exception($"{SysConfigNames.EnterpriseAbbr} SysConfig not found");
        }

        var encryptedAbbr = securityService.Decrypt(enterpriseAbbr, "ThC2RaPt3Ch20I7");
        return encryptedAbbr;
    }
}
