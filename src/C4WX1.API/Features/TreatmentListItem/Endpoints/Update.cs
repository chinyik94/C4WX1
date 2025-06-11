using C4WX1.API.Features.TreatmentListItem.Dtos;
using C4WX1.API.Features.TreatmentListItem.Mappers;

namespace C4WX1.API.Features.TreatmentListItem.Endpoints;

public class UpdateTreatmentListItemSummary
    : C4WX1UpdateSummary<Database.Models.TreatmentListItem>
{

}

public class Update(THCC_C4WDEVContext dbContext)
    : EndpointWithMapper<UpdateTreatmentListItemDto, UpdateTreatmentListItemMapper>
{
    public override void Configure()
    {
        Put("treatment-list-item/{id}");
        Summary(new UpdateTreatmentListItemSummary());
    }

    public override async Task HandleAsync(UpdateTreatmentListItemDto req, CancellationToken ct)
    {
        var entity = await dbContext.TreatmentListItem
            .Where(x => x.TListItemID == req.Id)
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
