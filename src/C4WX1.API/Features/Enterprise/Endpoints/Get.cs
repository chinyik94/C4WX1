using C4WX1.API.Features.Enterprise.Dtos;
using C4WX1.API.Features.Security;
using C4WX1.API.Features.Shared.Constants;
using C4WX1.API.Features.Shared.Extensions;
using C4WX1.API.Features.SysConfig.Constants;
using C4WX1.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace C4WX1.API.Features.Enterprise.Endpoints;

public class GetEnterpriseSummary : EndpointSummary
{
    public GetEnterpriseSummary()
    {
        Summary = "Get Enterprise";
        Description = "Get Enterprise";
        Responses[200] = "Enterprise retrieved successfully";
    }
}

public class Get(
    THCC_C4WDEVContext dbContext,
    ISecurityService securityService)
    : EndpointWithoutRequest<EnterpriseDto>
{
    private const string _passphrase = "ThC2RaPt3Ch20I7";
    private readonly ICollection<string> _enterpriseConfigNames = [
        SysConfigNames.EnterpriseName,
        SysConfigNames.EnterpriseAbbr,
        SysConfigNames.EnterpriseAddress1,
        SysConfigNames.EnterpriseAddress2,
        SysConfigNames.EnterpriseAddress3,
        SysConfigNames.EnterpriseContact,
        SysConfigNames.EnterpriseEmail,
        SysConfigNames.EnterpriseMaxUsers,
        SysConfigNames.EnterpriseMaxPatients,
        SysConfigNames.EnterpriseStartContract,
        SysConfigNames.EnterpriseEndContract,
        SysConfigNames.EnterpriseStatus
        ];

    public override void Configure()
    {
        Get("enterprise");
        Summary(new GetEnterpriseSummary());
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var enterpriseConfigValues = await dbContext.SysConfig
            .Where(x => _enterpriseConfigNames.Contains(x.ConfigName))
            .ToDictionaryAsync(x => x.ConfigName, x => x.ConfigValue, ct);

        string? Decrypt(string key) =>
            enterpriseConfigValues.TryGetValue(key, out var stringValue) 
            && !string.IsNullOrWhiteSpace(stringValue)
                ? securityService.Decrypt(stringValue, _passphrase)
                : null;

        int DecryptInt(string key)
        {
            var configValue = enterpriseConfigValues.TryGetValue(key, out var stringValue)
                ? stringValue
                : null;
            return int.TryParse(configValue, out var intValue) && intValue > 0
                ? intValue
                : 0;
        }

        DateTime? DecryptDate(string key)
        {
            var configValue = enterpriseConfigValues.TryGetValue(key, out var stringValue)
                ? stringValue
                : null;
            return configValue.ParseExact(DateFormats.Default);
        }

        var dto = new EnterpriseDto
        {
            Name = Decrypt(SysConfigNames.EnterpriseName),
            Abbr = Decrypt(SysConfigNames.EnterpriseAbbr),
            Address1 = Decrypt(SysConfigNames.EnterpriseAddress1),
            Address2 = Decrypt(SysConfigNames.EnterpriseAddress2),
            Address3 = Decrypt(SysConfigNames.EnterpriseAddress3),
            Contact = Decrypt(SysConfigNames.EnterpriseContact),
            Email = Decrypt(SysConfigNames.EnterpriseEmail),
            MaxUsers = DecryptInt(SysConfigNames.EnterpriseMaxUsers),
            MaxPatients = DecryptInt(SysConfigNames.EnterpriseMaxPatients),
            StartContract = DecryptDate(SysConfigNames.EnterpriseStartContract),
            EndContract = DecryptDate(SysConfigNames.EnterpriseEndContract),
            Status = Decrypt(SysConfigNames.EnterpriseStatus),
        };
        await SendOkAsync(dto, cancellation: ct);
    }
}
