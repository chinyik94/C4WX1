using C4WX1.API.Features.MobileAppVersioning.Dtos;
using C4WX1.API.Features.MobileAppVersioning.Mappers;

namespace C4WX1.API.Features.MobileAppVersioning.Endpoints;

public class CreateMobileAppVersioningSummary
    : C4WX1CreateSummary<Database.Models.MobileAppVersioning>
{
    public CreateMobileAppVersioningSummary() : base()
    {
        Responses[400] = "Version exists already";
    }
}

public class Create(THCC_C4WDEVContext dbContext)
    : Endpoint<CreateMobileAppVersioningDto, int, CreateMobileAppVersioningMapper>
{
    public override void Configure()
    {
        Post("mobile-app-versioning");
        Summary(new CreateMobileAppVersioningSummary());
    }

    public override async Task HandleAsync(CreateMobileAppVersioningDto req, CancellationToken ct)
    {
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

        var entity = Map.ToEntity(req);
        await dbContext.MobileAppVersioning.AddAsync(entity, ct);
        await dbContext.SaveChangesAsync(ct);
        await SendOkAsync(entity.MobileVersionId, ct);
    }
}
