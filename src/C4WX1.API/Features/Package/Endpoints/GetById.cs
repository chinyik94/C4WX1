using C4WX1.API.Features.Package.Dtos;
using C4WX1.API.Features.Package.Mappers;
using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.Package.Endpoints;

public class GetPackageByIdSummary
    : C4WX1GetByIdSummary<Database.Models.Package>
{

}

public class GetById(THCC_C4WDEVContext dbContext)
    : Endpoint<GetByIdDto, PackageDto, PackageMapper>
{
    public override void Configure()
    {
        Get("package/{id}");
        Summary(new GetPackageByIdSummary());
    }

    public override async Task HandleAsync(GetByIdDto req, CancellationToken ct)
    {
        var dto = await dbContext.Package
            .Where(x => x.PackageID == req.Id
                && !x.IsDeleted)
            .Select(x => Map.FromEntity(x))
            .FirstOrDefaultAsync(ct);
        await ((dto == null)
            ? SendNotFoundAsync(ct)
            : SendOkAsync(dto, ct));
    }
}
