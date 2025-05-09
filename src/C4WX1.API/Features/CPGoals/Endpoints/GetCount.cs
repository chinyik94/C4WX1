namespace C4WX1.API.Features.CPGoals.Endpoints;

public class GetCPGoalsCountSummary 
    : C4WX1GetCountSummary<Database.Models.CPGoals>
{
    public GetCPGoalsCountSummary() { }
}

public class GetCount(THCC_C4WDEVContext dbContext)
    : EndpointWithoutRequest<int>
{
    public override void Configure()
    {
        Get("cp-goals/count");
        Summary(new GetCPGoalsCountSummary());
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var count = await dbContext.CPGoals
            .Where(x => !x.IsDeleted)
            .CountAsync(ct);
        await SendOkAsync(count, cancellation: ct);
    }
}
