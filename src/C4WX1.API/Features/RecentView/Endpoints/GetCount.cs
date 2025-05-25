using C4WX1.API.Features.RecentView.Dtos;

namespace C4WX1.API.Features.RecentView.Endpoints;

public class GetRecentViewCountSummary
    : C4WX1GetCountSummary<Database.Models.RecentView>
{

}

public class GetCount(THCC_C4WDEVContext dbContext)
    : Endpoint<GetRecentViewCountDto, int>
{
    public override void Configure()
    {
        Get("recent-view/count");
        Summary(new GetRecentViewCountSummary());
    }

    public override async Task HandleAsync(GetRecentViewCountDto req, CancellationToken ct)
    {
        var count = await dbContext.RecentView
            .Where(x => x.UserID_FK == req.UserID)
            .CountAsync(ct);
        await SendOkAsync(count, ct);
    }
}
