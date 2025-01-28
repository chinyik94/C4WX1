using C4WX1.API.Features.SysConfig.Shared;
using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.SysConfig.Get
{
    public class GetSysConfigDto
    {
        [QueryParam]
        public string ConfigName { get; set; } = null!;
    }

    public class GetSysConfigSummary : EndpointSummary
    {
        public GetSysConfigSummary()
        {
            Summary = $"Get {nameof(SysConfig)}";
            Description = $"Get {nameof(SysConfig)} by ID or Access Key";
            Responses[200] = $"{nameof(SysConfig)} retrieved successfully";
            Responses[404] = $"{nameof(SysConfig)} not found";
        }
    }

    public class Get(
        THCC_C4WDEVContext dbContext): Endpoint<GetSysConfigDto, SysConfigDto, SysConfigMapper>
    {
        public override void Configure()
        {
            Get("sysconfig");
            Description(b => b
                .Produces<SysConfigDto>()
                .Produces(404)
                .ProducesProblemFE<InternalErrorResponse>(500));
            Summary(new GetSysConfigSummary());
        }

        public override async Task HandleAsync(GetSysConfigDto req, CancellationToken ct)
        {
            var entity = await dbContext.SysConfig
                .FirstOrDefaultAsync(x => x.ConfigName == req.ConfigName, ct);
            if (entity == null)
            {
                await SendNotFoundAsync(ct);
                return;
            }

            var dto = Map.FromEntity(entity);
            await SendAsync(dto, cancellation: ct);
        }
    }
}
