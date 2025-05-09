using C4WX1.API.Features.GeoFencing.Dtos;
using C4WX1.API.Features.GeoFencing.Extensions;
using C4WX1.API.Features.GeoFencing.Mappers;
using C4WX1.API.Features.Shared.Dtos;
using C4WX1.API.Features.Shared.Extensions;

namespace C4WX1.API.Features.GeoFencing.Endpoints;

public class GetGeoFencingListSummary 
    : C4WX1GetListSummary<Database.Models.GeoFencing>
{
    public GetGeoFencingListSummary() { }
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
        var (startRowIndex, pageSize) = req.GetPaginationDetails();
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
