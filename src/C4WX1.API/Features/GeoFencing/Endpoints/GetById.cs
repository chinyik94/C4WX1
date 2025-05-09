using C4WX1.API.Features.GeoFencing.Dtos;
using C4WX1.API.Features.GeoFencing.Mappers;
using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.GeoFencing.Endpoints;

public class GetGeoFencingByIdSummary 
    : C4WX1GetByIdSummary<Database.Models.GeoFencing>
{
    public GetGeoFencingByIdSummary() { }
}

public class GetById(THCC_C4WDEVContext dbContext)
    : Endpoint<GetByIdDto, GeoFencingDto, GeoFencingMapper>
{
    public override void Configure()
    {
        Get("geofencing/{id}");
        Summary(new GetGeoFencingByIdSummary());
    }

    public override async Task HandleAsync(GetByIdDto req, CancellationToken ct)
    {
        var dto = await dbContext.GeoFencing
            .Where(x => !x.IsDeleted
                && x.GeoFencingId == req.Id)
            .Select(x => Map.FromEntity(x))
            .FirstOrDefaultAsync(ct);

        await ((dto == null)
            ? SendNotFoundAsync(ct)
            : SendOkAsync(dto, cancellation: ct));
    }
}
