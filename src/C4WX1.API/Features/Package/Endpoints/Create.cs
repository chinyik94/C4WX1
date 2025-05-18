using C4WX1.API.Features.Package.Dtos;
using C4WX1.API.Features.Package.Mappers;

namespace C4WX1.API.Features.Package.Endpoints;

public class CreatePackageSummary
    : C4WX1CreateSummary<Database.Models.Package>
{

}

public class Create(THCC_C4WDEVContext dbContext)
    : Endpoint<CreatePackageDto, int, CreatePackageMapper>
{
    public override void Configure()
    {
        Post("package");
        Summary(new CreatePackageSummary());
    }

    public override async Task HandleAsync(CreatePackageDto req, CancellationToken ct)
    {
        var entity = Map.ToEntity(req);
        await dbContext.Package.AddAsync(entity, ct);
        await dbContext.SaveChangesAsync(ct);
        await SendOkAsync(entity.PackageID, ct);
    }
}
