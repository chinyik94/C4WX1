using C4WX1.API.Features.Shared.Extensions;
using C4WX1.API.Features.TreatmentListItem.Dtos;
using C4WX1.API.Features.TreatmentListItem.Extensions;
using C4WX1.API.Features.TreatmentListItem.Mappers;

namespace C4WX1.API.Features.TreatmentListItem.Endpoints;

public class GetTreatmentListItemListSummary
    : C4WX1GetListSummary<Database.Models.TreatmentListItem>
{

}

public class GetList(THCC_C4WDEVContext dbContext)
    : Endpoint<GetTreatmentListItemListDto, IEnumerable<TreatmentListItemDto>, TreatmentListItemMapper>
{
    public override void Configure()
    {
        Get("treatment-list-item");
        Summary(new GetTreatmentListItemListSummary());
    }

    public override async Task HandleAsync(GetTreatmentListItemListDto req, CancellationToken ct)
    {
        var (startRowIndex, pageSize) = req.GetPaginationDetails();
        var dtos = await dbContext.TreatmentListItem
            .Include(x => x.TListTypeID_FKNavigation)
            .Where(x => !x.IsDeleted
                && (string.IsNullOrWhiteSpace(req.ProductName) || x.ItemName.Contains(req.ProductName))
                && (req.ProductType == null || x.TListTypeID_FK == req.ProductType))
            .Sort(req.OrderBy)
            .Skip(startRowIndex)
            .Take(pageSize)
            .Select(x => Map.FromEntity(x))
            .ToListAsync(ct);
        await SendOkAsync(dtos, ct);
    }
}
