using C4WX1.API.Features.MobileAppVersioning.Dtos;
using C4WX1.API.Features.MobileAppVersioning.Mappers;

namespace C4WX1.API.Features.MobileAppVersioning.Endpoints;

public class UpdateMobileAppVersioningSummary
    : C4WX1UpdateSummary<Database.Models.MobileAppVersioning>
{
    public UpdateMobileAppVersioningSummary() : base()
    {
        Responses[400] = "Version exists already";
    }
}

public class Update(THCC_C4WDEVContext dbContext)
    : EndpointWithMapper<UpdateMobileAppVersioningDto, UpdateMobileAppVersioningMapper>
{
    public override void Configure()
    {
        Put("mobile-app-versioning/{id}");
        Summary(new UpdateMobileAppVersioningSummary());
    }

    public override async Task HandleAsync(UpdateMobileAppVersioningDto req, CancellationToken ct)
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

        var isVersionConflicts = await dbContext.MobileAppVersioning
            .Where(x => x.AppName == req.AppName
                && x.DeviceType == req.DeviceType
                && x.Version == req.Version
                && !(x.IsDeleted ?? false))
            .AnyAsync(ct);
        if (isVersionConflicts)
        {
            ThrowError("Version exists already");
            return;
        }

        entity = Map.UpdateEntity(req, entity);
        await dbContext.SaveChangesAsync(ct);
        await SendNoContentAsync(ct);
    }
}
