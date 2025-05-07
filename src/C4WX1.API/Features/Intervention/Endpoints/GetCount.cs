using C4WX1.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace C4WX1.API.Features.Intervention.Endpoints;

public class GetInterventionCountSummary 
    : C4WX1GetCountSummary<Database.Models.Intervention>
{
    public GetInterventionCountSummary() { }
}

public class GetCount(THCC_C4WDEVContext dbContext)
    : EndpointWithoutRequest<int>
{
    public override void Configure()
    {
        Get("intervention/count");
        Summary(new GetInterventionCountSummary());
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var count = await dbContext.Intervention
            .Where(x => !x.IsDeleted)
            .CountAsync(ct);
        await SendOkAsync(count, ct);
    }
}
