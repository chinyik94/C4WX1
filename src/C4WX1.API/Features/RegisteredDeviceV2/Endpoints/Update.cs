using C4WX1.API.Features.RegisteredDeviceV2.Dtos;
using C4WX1.API.Features.RegisteredDeviceV2.Mappers;

namespace C4WX1.API.Features.RegisteredDeviceV2.Endpoints;

public class UpdateRegisteredDeviceV2Summary
    : C4WX1UpdateSummary<Database.Models.RegisteredDeviceV2>
{

}

public class Update(THCC_C4WDEVContext dbContext)
    : EndpointWithMapper<UpdateRegisteredDeviceV2Dto, UpdateRegisteredDeviceV2Mapper>
{
    public override void Configure()
    {
        Put("registered-device-v2/{id}");
        Summary(new UpdateRegisteredDeviceV2Summary());
    }

    public override async Task HandleAsync(UpdateRegisteredDeviceV2Dto req, CancellationToken ct)
    {
        var entity = await dbContext.RegisteredDeviceV2
            .Where(x => !x.IsDeleted
                && x.RegisteredDeviceID == req.Id)
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
