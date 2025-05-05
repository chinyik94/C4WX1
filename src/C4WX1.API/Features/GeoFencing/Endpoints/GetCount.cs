using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.GeoFencing.Endpoints;

public class GetGeoFencingCountSummary : EndpointSummary
{
    public GetGeoFencingCountSummary()
    {
        Summary = "Get GeoFencing Count";
        Description = "Get GeoFencing Count";
        Responses[200] = "GeoFencing count retrieved successfully";
    }
}

public class GetCount(THCC_C4WDEVContext dbContext)
    : EndpointWithoutRequest<int>
{
    public override void Configure()
    {
        Get("geofencing/count");
        Summary(new GetGeoFencingCountSummary());
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var count = await dbContext.GeoFencing
            .Where(x => !x.IsDeleted)
            .CountAsync(ct);
        await SendOkAsync(count, cancellation: ct);
    }
}
