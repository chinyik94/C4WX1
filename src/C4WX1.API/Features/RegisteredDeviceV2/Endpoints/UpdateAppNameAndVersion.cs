using C4WX1.API.Features.RegisteredDeviceV2.Dtos;
using C4WX1.API.Features.RegisteredDeviceV2.Mappers;

namespace C4WX1.API.Features.RegisteredDeviceV2.Endpoints;

public class UpdateRegisteredDeviceV2AppNameAndVersionSummary
    : C4WX1UpdateSummary<Database.Models.RegisteredDeviceV2>
{

}

public class UpdateAppNameAndVersion(THCC_C4WDEVContext dbContext)
    : EndpointWithMapper<UpdateRegisteredDeviceV2AppNameAndVersionDto, UpdateRegisteredDeviceV2AppNameAndVersionMapper>
{
    public override void Configure()
    {
        Put("registered-device-v2/app-name-version/{deviceId}");
        Summary(new UpdateRegisteredDeviceV2AppNameAndVersionSummary());
    }

    public override async Task HandleAsync(UpdateRegisteredDeviceV2AppNameAndVersionDto req, CancellationToken ct)
    {
        var entity = await dbContext.RegisteredDeviceV2
            .Where(x => !x.IsDeleted
                && x.DeviceId == req.DeviceId)
            .FirstOrDefaultAsync(ct);
        if (entity == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        entity = Map.UpdateEntity(req, entity);
        await dbContext.SaveChangesAsync(ct);
        await SendNoContentAsync(ct);
    }
}
