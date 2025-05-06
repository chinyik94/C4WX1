using C4WX1.API.Features.Shared.Dtos;
using C4WX1.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace C4WX1.API.Features.GeoFencing.Endpoints;

public class DeleteGeoFencingSummary : EndpointSummary
{
    public DeleteGeoFencingSummary()
    {
        Summary = "Delete GeoFencing";
        Description = "Delete an existing GeoFencing by its ID";
        Responses[200] = "GeoFencing deleted successfully";
        Responses[400] = "GeoFencing unable to be deleted";
    }
}

public class Delete(THCC_C4WDEVContext dbContext)
    : Endpoint<DeleteByIdDto>
{
    public override void Configure()
    {
        Delete("geofencing/{id}");
        Summary(new DeleteGeoFencingSummary());
    }

    public override async Task HandleAsync(DeleteByIdDto req, CancellationToken ct)
    {
        var entity = await dbContext.GeoFencing
            .Where(x => !x.IsDeleted
                && x.GeoFencingId == req.Id)
            .FirstOrDefaultAsync(ct);
        if (entity == null)
        {
            ThrowError("UNABLE_DELETE");
            return;
        }

        entity.IsDeleted = true;
        entity.ModifiedBy_FK = req.UserId;
        entity.ModifiedDate = DateTime.Now;
        await dbContext.SaveChangesAsync(ct);
        await SendNoContentAsync(ct);
    }
}
