namespace C4WX1.API.Features.SysConfig.Endpoints;

public class GetSysConfigCountSummary 
    : C4WX1GetCountSummary<Database.Models.SysConfig>
{
    public GetSysConfigCountSummary() { }
}

public class GetCount(THCC_C4WDEVContext dbContext) 
    : EndpointWithoutRequest<int>
{
    public override void Configure()
    {
        Get("sysconfig/count");
        Summary(new GetSysConfigCountSummary());
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var count = await dbContext.SysConfig.CountAsync(ct);
        await SendAsync(count, cancellation: ct);
    }
}
