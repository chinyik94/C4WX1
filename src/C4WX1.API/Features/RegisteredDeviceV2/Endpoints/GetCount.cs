
namespace C4WX1.API.Features.RegisteredDeviceV2.Endpoints;

public class GetRegisteredDeviceV2CountSummary
    : C4WX1GetCountSummary<Database.Models.RegisteredDeviceV2>
{

}

public class GetCount(THCC_C4WDEVContext dbContext)
    : EndpointWithoutRequest<int>
{
    public override void Configure()
    {
        Get("registered-device-v2/count");
        Summary(new GetRegisteredDeviceV2CountSummary());
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var count = await dbContext.RegisteredDeviceV2
            .Where(x => !x.IsDeleted)
            .CountAsync(ct);
        await SendOkAsync(count, ct);
    }
}
