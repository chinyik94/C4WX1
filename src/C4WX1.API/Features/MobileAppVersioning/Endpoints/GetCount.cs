
namespace C4WX1.API.Features.MobileAppVersioning.Endpoints;

public class GetMobileAppVersioningCountSummary
    : C4WX1GetCountSummary<Database.Models.MobileAppVersioning>
{

}

public class GetCount(THCC_C4WDEVContext dbContext)
    : EndpointWithoutRequest<int>
{
    public override void Configure()
    {
        Get("mobile-app-versioning/count");
        Summary(new GetMobileAppVersioningCountSummary());
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var count = await dbContext.MobileAppVersioning
            .Where(x => !(x.IsDeleted ?? false))
            .CountAsync(ct);
        await SendOkAsync(count, ct);
    }
}
