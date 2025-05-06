using C4WX1.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace C4WX1.API.Features.CPGoals.Endpoints;

public class GetCPGoalsCountSummary : EndpointSummary
{
    public GetCPGoalsCountSummary()
    {
        Summary = "Get CP Goals Count";
        Description = "Get the count of CP Goals";
        Responses[200] = "CP Goals Count retrieved successfully";
    }
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
