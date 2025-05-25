using C4WX1.API.Features.RegisteredDeviceV2.Dtos;

namespace C4WX1.API.Features.RegisteredDeviceV2.Endpoints;

public class GetListOfRegisteredDeviceV2Summary
    : C4WX1GetListSummary<Database.Models.RegisteredDeviceV2>
{

}

public class GetListOfDevices(THCC_C4WDEVContext dbContext)
    : EndpointWithoutRequest<IEnumerable<DeviceCountDto>>
{
    public override void Configure()
    {
        Get("registered-device-v2/device-count");
        Summary(new GetListOfRegisteredDeviceV2Summary());
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var dtos = await dbContext.RegisteredDeviceV2
            .Where(x => !x.IsDeleted)
            .GroupBy(x => x.Status)
            .Select(x => new DeviceCountDto
            {
                Status = x.Key ?? string.Empty,
                Count = x.Count()
            })
            .ToListAsync(ct);
        await SendOkAsync(dtos, ct);
    }
}
