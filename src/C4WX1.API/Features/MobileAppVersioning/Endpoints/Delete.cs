using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.MobileAppVersioning.Endpoints;

public class DeleteMobileAppVersioningSummary
    : C4WX1DeleteSummary<Database.Models.MobileAppVersioning>
{

}

public class Delete(THCC_C4WDEVContext dbContext)
    : Endpoint<DeleteByIdDto>
{
    public override void Configure()
    {
        Delete("mobile-app-versioning/{id}");
        Summary(new DeleteMobileAppVersioningSummary());
    }

    public override async Task HandleAsync(DeleteByIdDto req, CancellationToken ct)
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

        entity.IsDeleted = true;
        entity.ModifiedBy_FK = req.UserId;
        entity.ModifiedDate = DateTime.Now;
        await dbContext.SaveChangesAsync(ct);
        await SendNoContentAsync(ct);
    }
}
