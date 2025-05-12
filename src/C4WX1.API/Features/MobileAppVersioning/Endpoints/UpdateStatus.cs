using C4WX1.API.Features.MobileAppVersioning.Dtos;

namespace C4WX1.API.Features.MobileAppVersioning.Endpoints;

public class UpdateMobileAppVersioningStatusSummary
    : C4WX1UpdateSummary<Database.Models.MobileAppVersioning>
{

}

public class UpdateStatus(THCC_C4WDEVContext dbContext)
    : Endpoint<UpdateMobileAppVersioningStatusDto>
{
    public override void Configure()
    {
        Put("mobile-app-versioning/status/{id}");
        Summary(new UpdateMobileAppVersioningStatusSummary());
    }

    public override async Task HandleAsync(UpdateMobileAppVersioningStatusDto req, CancellationToken ct)
    {
        var entity = await dbContext.MobileAppVersioning
            .Where(x => x.MobileVersionId == req.Id
                && !(x.IsDeleted ?? false))
            .FirstOrDefaultAsync(ct);
        if (entity == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        entity.Status = req.Status;
        entity.ModifiedBy_FK = req.UserId;
        entity.ModifiedDate = DateTime.Now;
        await dbContext.SaveChangesAsync(ct);
        await SendNoContentAsync(ct);
    }
}
