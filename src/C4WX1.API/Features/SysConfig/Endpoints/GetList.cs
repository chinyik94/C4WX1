using C4WX1.API.Features.Shared.Constants;
using C4WX1.API.Features.SysConfig.Dtos;
using C4WX1.API.Features.SysConfig.Mappers;
using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.SysConfig.Endpoints;

public class GetSysConfigListSummary : EndpointSummary
{
    public GetSysConfigListSummary()
    {
        Summary = "Get SysConfig List";
        Description = "Get a filtered, paged and sorted list of SysConfigs";
        Responses[200] = "SysConfig List retrieved successfully";
    }
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
        var pageIndex = req.PageIndex ?? PaginationDefaults.Index;
        var pageSize = req.PageSize ?? PaginationDefaults.Size;
        var startRowIndex = Math.Max(0, (pageIndex - 1) * pageSize);

        var orderBy = string.IsNullOrWhiteSpace(req.OrderBy)
            ? SortDirections.Default
            : req.OrderBy;
        var order = orderBy.Split(' ');
        var sortColumn = order[0];
        var isDescending = order[1].Equals(SortDirections.Desc, StringComparison.OrdinalIgnoreCase);

        var query = dbContext.SysConfig
            .Where(x => (string.IsNullOrWhiteSpace(req.ConfigName) || x.ConfigName == req.ConfigName)
                && (string.IsNullOrWhiteSpace(req.ConfigValue) || x.ConfigValue == req.ConfigValue));

        query = sortColumn switch
        {
            "ConfigValue" => isDescending
                ? query.OrderByDescending(x => x.ConfigValue)
                : query.OrderBy(x => x.ConfigValue),
            _ => isDescending
                ? query.OrderByDescending(x => x.ConfigName)
                : query.OrderBy(x => x.ConfigName)
        };

        var dtos = await query
            .Skip(startRowIndex)
            .Take(pageSize)
            .Select(x => Map.FromEntity(x))
            .ToListAsync(ct);

        await SendAsync(dtos, cancellation: ct);
    }
}
