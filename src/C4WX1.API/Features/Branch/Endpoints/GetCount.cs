namespace C4WX1.API.Features.Branch.Endpoints;

public class GetBranchCountSummary 
    : C4WX1GetCountSummary<Database.Models.Branch>
{
    public GetBranchCountSummary() { }
}

public class GetCount(THCC_C4WDEVContext dbContext)
    : EndpointWithoutRequest<int>
{
    public override void Configure()
    {
        Get("branch/count");
        Summary(new GetBranchCountSummary());
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var count = await dbContext.Branch
            .CountAsync(x => !x.IsDeleted, ct);

        await SendOkAsync(count, cancellation: ct);
    }
}
