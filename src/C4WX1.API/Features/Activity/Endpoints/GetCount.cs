using C4WX1.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace C4WX1.API.Features.Activity.Endpoints;

public class GetActivityCountSummary : EndpointSummary
{
    public GetActivityCountSummary()
    {
        Summary = "Get Activity Count";
        Description = "Get the number of activities";
        Responses[200] = "Number of activities retrieved successfully";
    }
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
