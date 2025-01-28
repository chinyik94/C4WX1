using C4WX1.API.Features.Activity.Get;
using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.SysConfig.Get
{
    public class GetSysConfigCountSummary : EndpointSummary
    {
        public GetSysConfigCountSummary()
        {
            Summary = $"Get {nameof(SysConfig)} count";
            Description = $"Get the number of {nameof(SysConfig)}s";
            Responses[200] = $"Number of {nameof(SysConfig)}s retrieved successfully";
        }
    }

    public class GetCount(
        THCC_C4WDEVContext dbContext) : EndpointWithoutRequest<int>
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
}
