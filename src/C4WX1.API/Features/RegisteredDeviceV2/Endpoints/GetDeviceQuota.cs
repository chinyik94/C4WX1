using C4WX1.API.Features.RegisteredDeviceV2.Dtos;
using C4WX1.API.Features.SysConfig.Constants;

namespace C4WX1.API.Features.RegisteredDeviceV2.Endpoints;

public class GetRegisteredDeviceV2QuotaSummary
    : C4WX1GetByIdSummary<Database.Models.RegisteredDeviceV2>
{

}

public class GetDeviceQuota(THCC_C4WDEVContext dbContext)
    : EndpointWithoutRequest<DeviceCountDto>
{
    public override void Configure()
    {
        Get("registered-device-v2/device-quota");
        Summary(new GetRegisteredDeviceV2QuotaSummary());
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var quotaEnabledConfigValue = await dbContext.SysConfig
            .Where(x => x.ConfigName == SysConfigNames.EnableRegisteredDeviceV2_Quota)
            .Select(x => x.ConfigValue)
            .FirstOrDefaultAsync(ct);
        if (!bool.TryParse(quotaEnabledConfigValue, out var isEnabled) || !isEnabled)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        var quotaNumberConfigValue = await dbContext.SysConfig
            .Where(x => x.ConfigName == SysConfigNames.RegisteredDeviceV2_QuotaNumber)
            .Select(x => x.ConfigValue)
            .FirstOrDefaultAsync(ct);
        if (!int.TryParse(quotaNumberConfigValue, out var quotaNumber))
        {
            await SendNotFoundAsync(ct);
            return;
        }

        var dto = new DeviceCountDto
        {
            Status = "Quota",
            Count = quotaNumber
        };
        await SendOkAsync(dto, ct);
    }
}
