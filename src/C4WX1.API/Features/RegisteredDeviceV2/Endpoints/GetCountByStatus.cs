using C4WX1.API.Features.RegisteredDeviceV2.Dtos;

namespace C4WX1.API.Features.RegisteredDeviceV2.Endpoints;

public class GetRegisteredDeviceV2CountByStatusSummary
    : C4WX1GetCountSummary<Database.Models.RegisteredDeviceV2>
{

}

public class GetCountByStatus(THCC_C4WDEVContext dbContext)
    : Endpoint<GetRegisteredDeviceV2CountByStatusDto, int>
{
    public override void Configure()
    {
        Get("registered-device-v2/count-by-status/{status}");
        Summary(new GetRegisteredDeviceV2CountByStatusSummary());
    }

    public override async Task HandleAsync(GetRegisteredDeviceV2CountByStatusDto req, CancellationToken ct)
    {
        var count = await dbContext.RegisteredDeviceV2
            .Where(x => !x.IsDeleted
                && x.Status == req.Status)
            .CountAsync(ct);
        await SendOkAsync(count, ct);
    }
}
