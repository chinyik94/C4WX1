using C4WX1.API.Features.MobileAppVersioning.Dtos;
using C4WX1.API.Features.MobileAppVersioning.Enums;
using C4WX1.API.Features.Shared.Constants;
using C4WX1.API.Features.SysConfig.Constants;

namespace C4WX1.API.Features.MobileAppVersioning.Endpoints;

public class GetIsMobileAppVersioningAbleLoginSummary
    : EndpointSummary
{
    public GetIsMobileAppVersioningAbleLoginSummary()
    {
        Summary = "Get MobileAppVersioning Is Able Login";
        Description = "Get MobileAppVersioning Is Able Login by its ID";
        Responses[200] = "MobileAppVersioning Is Able Login retrieved successfully";
    }
}

public class GetIsAbleLogin(THCC_C4WDEVContext dbContext)
    : Endpoint<GetIsMobileAppVersioningAbleLoginDto, int>
{
    public override void Configure()
    {
        Get("mobile-app-versioning/is-able-login");
        Summary(new GetIsMobileAppVersioningAbleLoginSummary());
    }

    public override async Task HandleAsync(GetIsMobileAppVersioningAbleLoginDto req, CancellationToken ct)
    {
        var isMobileAppVersionCheckingEnabled = await dbContext.SysConfig
            .Where(x => x.ConfigName == SysConfigNames.EnableMobileAppVersionChecking)
            .Select(x => x.ConfigValue)
            .FirstOrDefaultAsync(ct);
        if (!bool.TryParse(isMobileAppVersionCheckingEnabled, out bool isEnabled) || !isEnabled)
        {
            await SendOkAsync((int)IsAbleLogin.YesButSysConfigDisabled, ct);
            return;
        }

        var status = await dbContext.MobileAppVersioning
            .Where(x => x.AppName == req.AppName
                && x.DeviceType == req.DeviceType
                && x.Version == req.Version)
            .Select(x => x.Status)
            .FirstOrDefaultAsync(ct);
        var returnCode = status switch
        {
            Statuses.Active => (int)IsAbleLogin.YesVersionActive,
            Statuses.Pending => (int)IsAbleLogin.NoVersionPending,
            Statuses.ForcedUpdate => (int)IsAbleLogin.NoVersionForcedUpdate,
            _ => (int)IsAbleLogin.NoVersionNotFound
        };
        await SendOkAsync(returnCode, ct);
    }
}
