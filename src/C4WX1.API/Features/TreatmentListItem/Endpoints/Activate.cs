using C4WX1.API.Features.TreatmentListItem.Dtos;

namespace C4WX1.API.Features.TreatmentListItem.Endpoints;

public class ActivateTreatmentListItemSummary
    : EndpointSummary
{
    public ActivateTreatmentListItemSummary()
    {
        Summary = "Activate TreatmentListItem";
        Description = "Activate TreatmentListItem";
        Responses[204] = "TreatmentListItem activated successfully";
        Responses[400] = "Unable to activate TreatmentListItem";
        Responses[404] = "TreatmentListItem not found";
    }
}

public class Activate(THCC_C4WDEVContext dbContext)
    : Endpoint<ActivateTreatmentListItemDto>
{
    public override void Configure()
    {
        Post("treatment-list-item/deactivate/{id}");
        Summary(new ActivateTreatmentListItemSummary());
    }

    public override async Task HandleAsync(ActivateTreatmentListItemDto req, CancellationToken ct)
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

        entity.IsActive = true;
        entity.ModifiedBy_FK = req.UserId;
        entity.ModifiedDate = DateTime.Now;
        await dbContext.SaveChangesAsync(ct);
        await SendNoContentAsync(ct);
    }
}
