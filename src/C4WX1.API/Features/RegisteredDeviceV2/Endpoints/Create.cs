using C4WX1.API.Features.RegisteredDeviceV2.Dtos;
using C4WX1.API.Features.RegisteredDeviceV2.Mappers;

namespace C4WX1.API.Features.RegisteredDeviceV2.Endpoints;

public class CreateRegisteredDeviceV2Summary
    : C4WX1CreateSummary<Database.Models.RegisteredDeviceV2>
{

}

public class Create(THCC_C4WDEVContext dbContext)
    : Endpoint<CreateRegisteredDeviceV2Dto, int, CreateRegisteredDeviceV2Mapper>
{
    public override void Configure()
    {
        Post("registered-device-v2");
        Summary(new CreateRegisteredDeviceV2Summary());
    }

    public override async Task HandleAsync(CreateRegisteredDeviceV2Dto req, CancellationToken ct)
    {
        var entities = await dbContext.RegisteredDeviceV2
            .Where(x => x.DeviceId == req.DeviceId)
            .ToListAsync(ct);
        bool isAllDeleted = entities.All(x => x.IsDeleted);
        if (entities.Count != 0 && !isAllDeleted)
        {
            ThrowError("UNABLE_INSERT");
            return;
        }

        var entity = Map.ToEntity(req);
        await dbContext.RegisteredDeviceV2.AddAsync(entity, ct);
        await dbContext.SaveChangesAsync(ct);
        await SendOkAsync(entity.RegisteredDeviceID, ct);
    }
}
