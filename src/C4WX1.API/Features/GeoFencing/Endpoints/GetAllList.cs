using C4WX1.API.Features.GeoFencing.Dtos;
using C4WX1.API.Features.GeoFencing.Mappers;
using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.GeoFencing.Endpoints;

public class GetAllGeoFencingListSummary : EndpointSummary
{
    public GetAllGeoFencingListSummary()
    {
        Summary = "Get List of All GeoFencing";
        Description = "Get a sorted list of all GeoFencing";
        Responses[200] = "GeoFencing List retrieved successfully";
    }
}

public class GetAllList(THCC_C4WDEVContext dbContext)
    : EndpointWithoutRequest<IEnumerable<GeoFencingDto>, GeoFencingMapper>
{
    public override void Configure()
    {
        Get("geofencing/all");
        Summary(new GetAllGeoFencingListSummary());
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var dtos = await dbContext.GeoFencing
            .Where(x => !x.IsDeleted)
            .OrderBy(x => x.IP)
            .Select(x => Map.FromEntity(x))
            .ToListAsync(ct);
        await SendOkAsync(dtos, cancellation: ct);
    }
}
