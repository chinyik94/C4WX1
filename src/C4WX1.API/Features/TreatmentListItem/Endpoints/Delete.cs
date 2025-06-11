using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.TreatmentListItem.Endpoints;

public class DeleteTreatmentListItemSummary
    : C4WX1DeleteSummary<Database.Models.TreatmentListItem>
{

}

public class Delete(THCC_C4WDEVContext dbContext)
    : Endpoint<DeleteByIdDto>
{
    public override void Configure()
    {
        Delete("treatment-list-item/{id}");
        Summary(new DeleteTreatmentListItemSummary());
    }

    public override async Task HandleAsync(DeleteByIdDto req, CancellationToken ct)
    {
        var entity = await dbContext.TreatmentListItem
            .Include(x => x.PatientWoundVisitTreatmentList)
            .Where(x => !x.IsDeleted
                && x.TListItemID == req.Id)
            .FirstOrDefaultAsync(ct);
        if (entity == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        var canDelete = !(entity.IsSystemUsed ?? false)
            && !entity.PatientWoundVisitTreatmentList
                .Any(x => x.TListItemID_FK == entity.TListItemID
                    && !x.IsDeleted);
        if (!canDelete)
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
