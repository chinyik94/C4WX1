using C4WX1.API.Features.Item.Dtos;

namespace C4WX1.API.Features.Item.Endpoints;

public class GetItemCountSummary 
    : C4WX1GetCountSummary<Database.Models.Item>
{

}

public class GetCount(THCC_C4WDEVContext dbContext)
    : Endpoint<GetItemCountDto, int>
{
    public override void Configure()
    {
        Get("item/count");
        Summary(new GetItemCountSummary());
    }

    public override async Task HandleAsync(GetItemCountDto req, CancellationToken ct)
    {
        var count = await dbContext.Item
            .Where(x => !x.IsDeleted
                && (string.IsNullOrWhiteSpace(req.Keyword) || x.ItemName.Contains(req.Keyword)
                && (req.GroupId == null || x.CategoryID_FK == req.GroupId)
                && (req.AvailableInBilling == null || x.AvailableInBilling == req.AvailableInBilling)))
            .CountAsync(ct);
        await SendOkAsync(count, ct);
    }
}
