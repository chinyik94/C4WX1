namespace C4WX1.API.Features.Activity.Endpoints;

public class GetActivityCountSummary 
    : C4WX1GetCountSummary<Database.Models.Activity>
{
    public GetActivityCountSummary() { }
}

public class GetCount(THCC_C4WDEVContext dbContext)
    : EndpointWithoutRequest<int>
{
    public override void Configure()
    {
        Get("activity/count");
        Summary(new GetActivityCountSummary());
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var count = await dbContext.Activity.CountAsync(a => !a.IsDeleted, ct);
        await SendAsync(count, cancellation: ct);
    }
}
