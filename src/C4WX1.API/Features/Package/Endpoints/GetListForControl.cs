using C4WX1.API.Features.Package.Dtos;

namespace C4WX1.API.Features.Package.Endpoints;

public class GetPackageListForControlSummary
    : C4WX1GetListSummary<Database.Models.Package>
{

}

public class GetListForControl(THCC_C4WDEVContext dbContext)
    : EndpointWithoutRequest<IEnumerable<PackageDto>>
{
    public override void Configure()
    {
        Get("package/list/control");
        Summary(new GetPackageListForControlSummary());
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var dtos = await dbContext.Package
            .Where(x => !x.IsDeleted)
            .OrderByDescending(x => x.PackageName)
            .Select(x => new PackageDto
            {
                PackageName = x.PackageName,
                PackageDetails = x.PackageDetails,
            })
            .ToListAsync(ct);
        await SendOkAsync(dtos, ct);
    }
}
