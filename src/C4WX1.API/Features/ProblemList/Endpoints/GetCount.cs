
namespace C4WX1.API.Features.ProblemList.Endpoints;

public class GetProblemListCountSummary
    : C4WX1GetCountSummary<Database.Models.ProblemList>
{

}

public class GetCount(THCC_C4WDEVContext dbContext)
    : EndpointWithoutRequest<int>
{
    public override void Configure()
    {
        Get("problem-list/count");
        Summary(new GetProblemListCountSummary());
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var count = await dbContext.ProblemList
            .Where(x => !x.IsDeleted)
            .CountAsync(ct);
        await SendOkAsync(count, ct);
    }
}
