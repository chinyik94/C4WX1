using C4WX1.API.Features.GeoFencing.Dtos;
using C4WX1.API.Features.GeoFencing.Mappers;
using C4WX1.Database.Models;
using FastEndpoints;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.GeoFencing.Endpoints;

public class CreateGeoFencingSummary : EndpointSummary
{
    public CreateGeoFencingSummary()
    {
        Summary = "Create GeoFencing";
        Description = "Create a new GeoFencing";
        ExampleRequest = new CreateGeoFencingDto
        {
            IP = "example-IP",
            Description = "example-Description",
            UserId = 1
        };
        Responses[200] = "GeoFencing created successfully";
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
