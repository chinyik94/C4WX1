using C4WX1.API.Features.GeoFencing.Dtos;
using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.GeoFencing.Endpoints;

public class GetGeoFencingIsWhitelistedSummary : EndpointSummary
{
    public GetGeoFencingIsWhitelistedSummary()
    {
        Summary = "Get GeoFencing IsWhitelisted";
        Description = "Get GeoFencing IsWhitelisted by its ID";
        Responses[200] = "GeoFencing IsWhitelisted retrieved successfully";
    }
}

public class GetIsWhitelisted(THCC_C4WDEVContext dbContext)
    : Endpoint<GetGeoFencingIsWhiteListedDto, bool>
{
    public override void Configure()
    {
        Get("geofencing/iswhitelisted");
        Summary(new GetGeoFencingIsWhitelistedSummary());
    }

    public override async Task HandleAsync(GetGeoFencingIsWhiteListedDto req, CancellationToken ct)
    {
        var isExist = await dbContext.GeoFencing
            .Where(x => !x.IsDeleted
                && x.IP == req.IP
                && (x.IsWhitelisted ?? false))
            .AnyAsync(ct);
        await SendOkAsync(isExist, cancellation: ct);
    }
}
