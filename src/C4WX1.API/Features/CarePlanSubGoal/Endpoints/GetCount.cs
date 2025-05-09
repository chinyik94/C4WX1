namespace C4WX1.API.Features.CarePlanSubGoal.Endpoints;

public class GetCarePlanSubGoalCountSummary 
    : C4WX1GetCountSummary<Database.Models.CarePlanSubGoal>
{
    public GetCarePlanSubGoalCountSummary() { }
}

public class GetCount(THCC_C4WDEVContext dbContext)
    : EndpointWithoutRequest<int>
{
    public override void Configure()
    {
        Get("care-plan-sub-goal/count");
        Summary(new GetCarePlanSubGoalCountSummary());
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var count = await dbContext.CarePlanSubGoal
            .CountAsync(x => !(x.IsDeleted ?? false), ct);
        await SendOkAsync(count, cancellation: ct);
    }
}
