using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.CarePlanSubGoal.Get
{
    public class GetCarePlanSubGoalCountSummary : EndpointSummary
    {
        public GetCarePlanSubGoalCountSummary()
        {
            Summary = "Get Care Plan Sub Goal Count";
            Description = "Get Care Plan Sub Goal Count";
            Responses[200] = "Care Plan Sub Goal Count retrieved successfully";
        }
    }

    public class GetCount(THCC_C4WDEVContext dbContext)
        : EndpointWithoutRequest<int>
    {
        public override void Configure()
        {
            Get("care-plan-sub-goal/count");
            Summary(new GetCarePlanSubGoalCountSummary());
            Description(b => b
                .Produces<int>()
                .ProducesProblemFE<InternalErrorResponse>(500));
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var count = await dbContext.CarePlanSubGoal
                .CountAsync(x => !(x.IsDeleted ?? false), ct);
            await SendOkAsync(count, cancellation: ct);
        }
    }
}
