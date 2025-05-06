using C4WX1.API.Features.GeoFencing.Dtos;
using C4WX1.API.Features.GeoFencing.Mappers;
using C4WX1.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace C4WX1.API.Features.GeoFencing.Endpoints;

public class UpdateGeoFencingSummary : EndpointSummary
{
    public UpdateGeoFencingSummary()
    {
        Summary = "Update GeoFencing";
        Description = "Update a existing GeoFencing by its ID";
        ExampleRequest = new UpdateGeoFencingDto
        {
            Id = 1,
            IP = "example-IP",
            Description = "example-Description",
            UserId = 1
        };
        Responses[204] = "GeoFencing created successfully";
        Responses[400] = "Duplicate GeoFencing name";
        Responses[404] = "GeoFencing not found";
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
