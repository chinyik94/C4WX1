namespace C4WX1.API.Features.GeoFencing.Endpoints;

public class GetGeoFencingCountSummary 
    : C4WX1GetCountSummary<Database.Models.GeoFencing>
{
    public GetGeoFencingCountSummary() { }
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
