using C4WX1.API.Features.SysConfig.Dtos;
using C4WX1.API.Features.SysConfig.Mappers;
using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.SysConfig.Get;

public class GetSysConfigSummary : EndpointSummary
{
    public GetSysConfigSummary()
    {
        Summary = "Get SysConfig";
        Description = "Get SysConfig by its ConfigName";
        Responses[200] = "SysConfig retrieved successfully";
        Responses[404] = "SysConfig not found";
    }
}

public class Get(THCC_C4WDEVContext dbContext)
    : Endpoint<GetSysConfigDto, SysConfigDto, SysConfigGetMapper>
{
    public override void Configure()
    {
        Get("sysconfig/config-name/{configName}");
        Description(b => b.Produces(404));
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
