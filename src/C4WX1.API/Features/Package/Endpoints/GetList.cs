using C4WX1.API.Features.Package.Dtos;
using C4WX1.API.Features.Package.Extensions;
using C4WX1.API.Features.Package.Mappers;
using C4WX1.API.Features.Shared.Dtos;
using C4WX1.API.Features.Shared.Extensions;

namespace C4WX1.API.Features.Package.Endpoints;

public class GetPackageListSummary
    : C4WX1GetListSummary<Database.Models.Package>
{

}

public class GetList(THCC_C4WDEVContext dbContext)
    : Endpoint<GetListDto, IEnumerable<PackageDto>, PackageMapper>
{
    public override void Configure()
    {
        Get("package");
        Summary(new GetPackageListSummary());
    }

    public override async Task HandleAsync(GetListDto req, CancellationToken ct)
    {
        var (startRowIndex, pageSize) = req.GetPaginationDetails();
        var dtos = await dbContext.Package
            .Where(x => !x.IsDeleted)
            .Sort(req.OrderBy)
            .Skip(startRowIndex)
            .Take(pageSize)
            .Select(x => Map.FromEntity(x))
            .ToListAsync(ct);
        await SendOkAsync(dtos, ct);
    }
}
