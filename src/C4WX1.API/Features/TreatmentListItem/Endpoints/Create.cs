using C4WX1.API.Features.TreatmentListItem.Dtos;
using C4WX1.API.Features.TreatmentListItem.Mappers;

namespace C4WX1.API.Features.TreatmentListItem.Endpoints;

public class CreateTreatmentListItemSummary
    : C4WX1CreateSummary<Database.Models.TreatmentListItem>
{

}

public class Create(THCC_C4WDEVContext dbContext)
    : Endpoint<CreateTreatmentListItemDto, int, CreateTreatmentListItemMapper>
{
    public override void Configure()
    {
        Post("treatment-list-item");
        Summary(new CreateTreatmentListItemSummary());
    }

    public override async Task HandleAsync(CreateTreatmentListItemDto req, CancellationToken ct)
    {
        var entity = Map.ToEntity(req);
        await dbContext.TreatmentListItem.AddAsync(entity, ct);
        await dbContext.SaveChangesAsync(ct);
        await SendOkAsync(entity.TListItemID, ct);
    }
}
