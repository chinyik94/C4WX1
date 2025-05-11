using C4WX1.API.Features.Item.Dtos;
using C4WX1.API.Features.Item.Mappers;

namespace C4WX1.API.Features.Item.Endpoints;

public class GetItemListByTypeSummary : EndpointSummary
{
    public GetItemListByTypeSummary()
    {
        Summary = "Get Item List";
        Description = "Get Item List by Category Type";
        Responses[200] = "Item List retrieved successfully";
    }
}

public class GetListByType(THCC_C4WDEVContext dbContext)
    : Endpoint<GetItemListByTypeDto, IEnumerable<ItemDto>, ItemMapper>
{
    public override void Configure()
    {
        Get("item/list/type/{TypeId}");
        Summary(new GetItemListByTypeSummary());
    }

    public override async Task HandleAsync(GetItemListByTypeDto req, CancellationToken ct)
    {
        var dtos = await dbContext.Item
            .Include(x => x.ItemUnitID_FKNavigation)
            .Include(x => x.CategoryID_FKNavigation)
            .Include(x => x.BillingInvoiceConsumable)
                .ThenInclude(x => x.BillingInvoiceID_FKNavigation)
            .Where(x => !x.IsDeleted
                && x.CategoryID_FK == req.TypeId)
            .OrderBy(x => x.ItemName)
            .Select(x => Map.FromEntity(x))
            .ToListAsync(ct);
        await SendOkAsync(dtos, ct);
    }
}
