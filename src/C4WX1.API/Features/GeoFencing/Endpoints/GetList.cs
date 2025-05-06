using C4WX1.API.Features.GeoFencing.Dtos;
using C4WX1.API.Features.GeoFencing.Extensions;
using C4WX1.API.Features.GeoFencing.Mappers;
using C4WX1.API.Features.Shared.Constants;
using C4WX1.API.Features.Shared.Dtos;
using C4WX1.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace C4WX1.API.Features.GeoFencing.Endpoints;

public class GetGeoFencingListSummary : EndpointSummary
{
    public GetGeoFencingListSummary()
    {
        Summary = "Get List of GeoFencing";
        Description = "Get a filtered, sorted and paged list of GeoFencing";
        Responses[200] = "GeoFencing List retrieved successfully";
    }
}

public class GetList(THCC_C4WDEVContext dbContext)
    : Endpoint<GetListDto, IEnumerable<GeoFencingDto>, GeoFencingMapper>
{
    public override void Configure()
    {
        Get("geofencing");
        Summary(new GetGeoFencingListSummary());
    }

    public override async Task HandleAsync(GetListDto req, CancellationToken ct)
    {
        var pageIndex = req.PageIndex ?? PaginationDefaults.Index;
        var pageSize = req.PageSize ?? PaginationDefaults.Size;
        var startRowIndex = Math.Max(0, (pageIndex - 1) * pageSize);

        var dtos = await dbContext.GeoFencing
            .Where(x => !x.IsDeleted)
            .Sort(req.OrderBy)
            .Skip(startRowIndex)
            .Take(pageSize)
            .Select(x => Map.FromEntity(x))
            .ToListAsync(ct);
        await SendOkAsync(dtos, cancellation: ct);
    }
}
