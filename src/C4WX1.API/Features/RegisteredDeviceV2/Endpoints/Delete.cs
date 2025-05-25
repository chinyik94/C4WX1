using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.RegisteredDeviceV2.Endpoints;

public class DeleteRegisteredDeviceV2Summary
    : C4WX1DeleteSummary<Database.Models.RegisteredDeviceV2>
{

}

public class Delete(THCC_C4WDEVContext dbContext)
    : Endpoint<DeleteByIdDto>
{
    public override void Configure()
    {
        Delete("registered-device-v2/{id}");
        Summary(new DeleteRegisteredDeviceV2Summary());
    }

    public override async Task HandleAsync(DeleteByIdDto req, CancellationToken ct)
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
        entity.IsDeleted = true;
        entity.ModifiedBy_FK = req.UserId;
        entity.ModifiedDate = DateTime.Now;
        await dbContext.SaveChangesAsync(ct);
        await SendNoContentAsync(ct);
    }
}
