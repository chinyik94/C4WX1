using C4WX1.API.Features.Package.Dtos;
using C4WX1.API.Features.Package.Mappers;

namespace C4WX1.API.Features.Package.Endpoints;

public class UpdatePackageSummary
    : C4WX1UpdateSummary<Database.Models.Package>
{

}

public class Update(THCC_C4WDEVContext dbContext)
    : EndpointWithMapper<UpdatePackageDto, UpdatePackageMapper>
{
    public override void Configure()
    {
        Put("package/{id}");
        Summary(new UpdatePackageSummary());
    }

    public override async Task HandleAsync(UpdatePackageDto req, CancellationToken ct)
    {
        var isDuplicate = await dbContext.Package
            .Where(x => x.PackageName == req.PackageName
                && x.PackageID != req.Id
                && !x.IsDeleted)
            .AnyAsync(ct);
        if (isDuplicate)
        {
            ThrowError("DUPLICATE_NAME");
            return;
        }

        var entity = await dbContext.Package
            .Where(x => x.PackageID == req.Id)
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
