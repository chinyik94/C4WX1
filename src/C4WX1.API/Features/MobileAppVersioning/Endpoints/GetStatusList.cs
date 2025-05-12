using C4WX1.API.Features.MobileAppVersioning.Dtos;

namespace C4WX1.API.Features.MobileAppVersioning.Endpoints;

public class GetMobileAppVersioningStatusList
    : C4WX1GetListSummary<Database.Models.MobileAppVersioning>
{

}

public class GetStatusList(THCC_C4WDEVContext dbContext)
    : EndpointWithoutRequest<IEnumerable<MobileAppVersioningStatusDto>>
{
    public override void Configure()
    {
        Get("mobile-app-versioning/status-list");
        Summary(new GetMobileAppVersioningStatusList());
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var dtos = await dbContext.MobileAppVersioning
            .Where(x => !(x.IsDeleted ?? false))
            .GroupBy(x => x.Status)
            .Select(x => new MobileAppVersioningStatusDto
            {
                Status = x.Key,
                Count = x.Count()
            })
            .ToListAsync(ct);
        await SendOkAsync(dtos, ct);
    }
}
