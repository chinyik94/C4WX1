using C4WX1.API.Features.GeoFencing.Dtos;
using C4WX1.API.Features.GeoFencing.Mappers;

namespace C4WX1.API.Features.GeoFencing.Endpoints;

public class UpdateGeoFencingSummary 
    : C4WX1UpdateSummary<Database.Models.GeoFencing>
{
    public UpdateGeoFencingSummary() : base()
    {
        ExampleRequest = new UpdateGeoFencingDto
        {
            Id = 1,
            IP = "example-IP",
            Description = "example-Description",
            UserId = 1
        };
        Responses[400] = "Duplicate GeoFencing name";
    }
}

public class Update(THCC_C4WDEVContext dbContext)
    : EndpointWithMapper<UpdateGeoFencingDto, UpdateGeoFencingMapper>
{
    public override void Configure()
    {
        Put("geofencing/{id}");
        Summary(new UpdateGeoFencingSummary());
    }

    public override async Task HandleAsync(UpdateGeoFencingDto req, CancellationToken ct)
    {
        var isDuplicate = await dbContext.GeoFencing
            .Where(x => !x.IsDeleted
                && x.IP == req.IP
                && x.GeoFencingId != req.Id)
            .AnyAsync(ct);
        if (isDuplicate)
        {
            ThrowError("DUPLICATE_NAME");
            return;
        }

        var entity = await dbContext.GeoFencing
            .Where(x => !x.IsDeleted
                && x.GeoFencingId == req.Id)
            .FirstOrDefaultAsync(ct);
        if (entity == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        entity = Map.UpdateEntity(req, entity);
        await dbContext.SaveChangesAsync(ct);
        await SendNoContentAsync(ct);
    }
}
