using C4WX1.API.Features.SysConfig.Dtos;
using C4WX1.API.Features.SysConfig.Mappers;
using C4WX1.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace C4WX1.API.Features.SysConfig.Endpoints;

public class GetAllSysConfigListSummary : EndpointSummary
{
    public GetAllSysConfigListSummary()
    {
        Summary = "Get All SysConfig";
        Description = "Get all SysConfigs";
        Responses[200] = "SysConfig List retrieved successfully";
    }
}

public class GetAllList(THCC_C4WDEVContext dbContext) 
    : EndpointWithoutRequest<IEnumerable<SysConfigDto>, SysConfigGetMapper>
{
    public override void Configure()
    {
        Get("sysconfig/all");
        Summary(new GetAllSysConfigListSummary());
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var dtos = await dbContext.SysConfig
            .Select(x => Map.FromEntity(x))
            .ToListAsync(ct);

        await SendAsync(dtos, cancellation: ct);
    }
}
