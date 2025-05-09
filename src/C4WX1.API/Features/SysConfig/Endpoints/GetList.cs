using C4WX1.API.Features.Shared.Extensions;
using C4WX1.API.Features.SysConfig.Dtos;
using C4WX1.API.Features.SysConfig.Extensions;
using C4WX1.API.Features.SysConfig.Mappers;

namespace C4WX1.API.Features.SysConfig.Endpoints;

public class GetSysConfigListSummary
    : C4WX1GetListSummary<Database.Models.SysConfig>
{
    public GetSysConfigListSummary() { }
}

public class GetList(THCC_C4WDEVContext dbContext) 
    : Endpoint<GetSysConfigListDto, IEnumerable<SysConfigDto>, SysConfigGetMapper>
{
    public override void Configure()
    {
        Get("sysconfig");
        Summary(new GetSysConfigListSummary());
    }

    public override async Task HandleAsync(GetSysConfigListDto req, CancellationToken ct)
    {
        var (startRowIndex, pageSize) = req.GetPaginationDetails();
        var dtos = await dbContext.SysConfig
            .Where(x => (string.IsNullOrWhiteSpace(req.ConfigName) || x.ConfigName == req.ConfigName)
                && (string.IsNullOrWhiteSpace(req.ConfigValue) || x.ConfigValue == req.ConfigValue))
            .Sort(req.OrderBy)
            .Skip(startRowIndex)
            .Take(pageSize)
            .Select(x => Map.FromEntity(x))
            .ToListAsync(ct);

        await SendAsync(dtos, cancellation: ct);
    }
}
