using C4WX1.API.Features.Item.Dtos;
using C4WX1.API.Features.Item.Extensions;
using C4WX1.API.Features.Item.Mappers;
using C4WX1.API.Features.Shared.Dtos;
using C4WX1.API.Features.Shared.Extensions;

namespace C4WX1.API.Features.Item.Endpoints;

public class GetItemListSummary
    : C4WX1GetListSummary<Database.Models.Item>
{

}

public class GetList(THCC_C4WDEVContext dbContext)
    : Endpoint<GetItemListDto, IEnumerable<ItemDto>, ItemMapper>
{
    public override void Configure()
    {
        Get("item");
        Summary(new GetItemListSummary());
    }

    public override async Task HandleAsync(GetItemListDto req, CancellationToken ct)
    {
        var (startRowIndex, pageSize) = req.GetPaginationDetails();
        var dtos = await dbContext.Item
            .Include(x => x.ItemUnitID_FKNavigation)
            .Include(x => x.CategoryID_FKNavigation)
            .Include(x => x.BillingInvoiceConsumable)
                .ThenInclude(x => x.BillingInvoiceID_FKNavigation)
            .Where(x => !x.IsDeleted
                && (string.IsNullOrWhiteSpace(req.Keyword) || x.ItemName.Contains(req.Keyword)
                && (req.GroupId == null || x.CategoryID_FK == req.GroupId)
                && (req.AvailableInBilling == null || x.AvailableInBilling == req.AvailableInBilling)))
            .Sort(req.OrderBy)
            .Skip(startRowIndex)
            .Take(pageSize)
            .Select(x => Map.FromEntity(x))
            .ToListAsync(ct);
        await SendOkAsync(dtos, ct);
    }
}
