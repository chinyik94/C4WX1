using C4WX1.API.Features.Item.Dtos;
using C4WX1.API.Features.Item.Mappers;

namespace C4WX1.API.Features.Item.Endpoints;

public class GetAllItemListByTypeSummary 
    : C4WX1GetListSummary<Database.Models.Item>
{
    public GetAllItemListByTypeSummary()
        : base("Category Type and optionally Available In Billing")
    {

    }
}

public class GetAllListByType(THCC_C4WDEVContext dbContext)
    : Endpoint<GetAllItemListByTypeDto, IEnumerable<ItemDto>, ItemMapper>
{
    public override void Configure()
    {
        Get("item/all-list/type/{TypeId}");
        Summary(new GetAllItemListByTypeSummary());
    }

    public override async Task HandleAsync(GetAllItemListByTypeDto req, CancellationToken ct)
    {
        var dtos = await dbContext.Item
            .Include(x => x.ItemUnitID_FKNavigation)
            .Include(x => x.CategoryID_FKNavigation)
            .Include(x => x.BillingInvoiceConsumable)
                .ThenInclude(x => x.BillingInvoiceID_FKNavigation)
            .Where(x => !x.IsDeleted
                && x.CategoryID_FK == req.TypeId
                && (req.AvailableInBilling == null) || x.AvailableInBilling == req.AvailableInBilling)
            .OrderBy(x => x.ItemName)
            .Select(x => Map.FromEntity(x))
            .ToListAsync(ct);
        await SendOkAsync(dtos, ct);
    }
}
