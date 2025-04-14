using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.SysConfig.Endpoints;

public class GetSysConfigCountSummary : EndpointSummary
{
    public GetSysConfigCountSummary()
    {
        Summary = "Get SysConfig Count";
        Description = "Get the number of SysConfigs";
        Responses[200] = "Number of SysConfigs retrieved successfully";
    }
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
