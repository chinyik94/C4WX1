using C4WX1.API.Features.Shared.Dtos;
using C4WX1.API.Features.TreatmentListItem.Dtos;
using C4WX1.API.Features.TreatmentListItem.Mappers;

namespace C4WX1.API.Features.TreatmentListItem.Endpoints;

public class GetTreatmentListItemByIdSummary
    : C4WX1GetByIdSummary<Database.Models.TreatmentListItem>
{

}

public class GetById(THCC_C4WDEVContext dbContext)
    : Endpoint<GetByIdDto, TreatmentListItemDto, TreatmentListItemMapper>
{
    public override void Configure()
    {
        Get("treatment-list-item/{id}");
        Summary(new GetTreatmentListItemByIdSummary());
    }

    public override async Task HandleAsync(GetByIdDto req, CancellationToken ct)
    {
        var dto = await dbContext.TreatmentListItem
            .Where(x => !x.IsDeleted
                && x.TListItemID == req.Id)
            .Select(x => Map.FromEntity(x))
            .FirstOrDefaultAsync(ct);
        await ((dto == null)
            ? SendNotFoundAsync(ct)
            : SendOkAsync(dto, ct));
    }
}
