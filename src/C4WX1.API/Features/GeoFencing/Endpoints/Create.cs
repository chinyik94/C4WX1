using C4WX1.API.Features.GeoFencing.Dtos;
using C4WX1.API.Features.GeoFencing.Mappers;

namespace C4WX1.API.Features.GeoFencing.Endpoints;

public class CreateGeoFencingSummary 
    : C4WX1CreateSummary<Database.Models.GeoFencing>
{
    public CreateGeoFencingSummary() : base()
    {
        ExampleRequest = new CreateGeoFencingDto
        {
            IP = "example-IP",
            Description = "example-Description",
            UserId = 1
        };
    }
}

public class Create(THCC_C4WDEVContext dbContext)
    : Endpoint<CreateGeoFencingDto, int, CreateGeoFancingMapper>
{
    public override void Configure()
    {
        Post("geofencing");
        Summary(new CreateGeoFencingSummary());
    }

    public override async Task HandleAsync(CreateGeoFencingDto req, CancellationToken ct)
    {
        var entity = Map.ToEntity(req);
        await dbContext.GeoFencing.AddAsync(entity, ct);
        await dbContext.SaveChangesAsync(ct);
        await SendOkAsync(entity.GeoFencingId, ct);
    }
}
