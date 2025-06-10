using C4WX1.API.Features.TreatmentListItem.Dtos;

namespace C4WX1.API.Features.TreatmentListItem.Endpoints;

public class DeactivateTreatmentListItemSummary
    : EndpointSummary
{
    public DeactivateTreatmentListItemSummary()
    {
        Summary = "Deactivate TreatmentListItem";
        Description = "Deactivate TreatmentListItem";
        Responses[204] = "TreatmentListItem deactivated successfully";
        Responses[400] = "Unable to deactivate TreatmentListItem";
        Responses[404] = "TreatmentListItem not found";
    }
}

public class Deactivate(THCC_C4WDEVContext dbContext)
    : Endpoint<DeactivateTreatmentListItemDto>
{
    public override void Configure()
    {
        Post("treatment-list-item/deactivate/{id}");
        Summary(new DeactivateTreatmentListItemSummary());
    }

    public override async Task HandleAsync(DeactivateTreatmentListItemDto req, CancellationToken ct)
    {
        var entity = await dbContext.TreatmentListItem
            .Where(x => !x.IsDeleted
                && (x.IsActive ?? false)
                && x.TListItemID == req.Id)
            .FirstOrDefaultAsync(ct);
        if (entity == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        if (!(entity.IsSystemUsed ?? false))
        {
            ThrowError("UNABLE_DEACTIVATE");
            return;
        }

        entity.IsActive = false;
        entity.ModifiedBy_FK = req.UserId;
        entity.ModifiedDate = DateTime.Now;
        await dbContext.SaveChangesAsync(ct);
        await SendNoContentAsync(ct);
    }
}
