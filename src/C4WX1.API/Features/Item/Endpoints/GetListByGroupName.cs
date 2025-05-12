using C4WX1.API.Features.Item.Dtos;
using C4WX1.API.Features.Item.Mappers;

namespace C4WX1.API.Features.Item.Endpoints;

public class GetItemListByGroupNameSummary 
    : C4WX1GetListSummary<Database.Models.Item>
{
    public GetItemListByGroupNameSummary() : base("Group Name")
    {

    }
}

public class GetListByGroupName(THCC_C4WDEVContext dbContext)
    : Endpoint<GetItemListByGroupNameDto, IEnumerable<ItemDto>, ItemMapper>
{
    public override void Configure()
    {
        Get("item/list/group-name/{GroupName}");
        Summary(new GetItemListByGroupNameSummary());
    }

    public override async Task HandleAsync(GetItemListByGroupNameDto req, CancellationToken ct)
    {
        var dtos = await dbContext.Item
            .Include(x => x.ItemUnitID_FKNavigation)
            .Include(x => x.CategoryID_FKNavigation)
            .Include(x => x.BillingInvoiceConsumable)
                .ThenInclude(x => x.BillingInvoiceID_FKNavigation)
            .Where(x => !x.IsDeleted
                && x.CategoryID_FKNavigation.CodeName == req.GroupName)
            .OrderBy(x => x.ItemName)
            .Select(x => Map.FromEntity(x))
            .ToListAsync(ct);
        await SendOkAsync(dtos, ct);
    }
}
