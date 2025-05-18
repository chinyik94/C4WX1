
namespace C4WX1.API.Features.Package.Endpoints;

public class GetPackageCountSummary
    : C4WX1GetCountSummary<Database.Models.Package>
{

}

public class GetCount(THCC_C4WDEVContext dbContext)
    : EndpointWithoutRequest<int>
{
    public override void Configure()
    {
        Get("package/count");
        Summary(new GetPackageCountSummary());
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var count = await dbContext.Package
            .Where(x => !x.IsDeleted)
            .CountAsync(ct);
        await SendOkAsync(count, ct);
    }
}
