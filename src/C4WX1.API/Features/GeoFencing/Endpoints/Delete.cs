using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.GeoFencing.Endpoints;

public class DeleteGeoFencingSummary 
    : C4WX1DeleteSummary<Database.Models.GeoFencing>
{
    public DeleteGeoFencingSummary() { }
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
