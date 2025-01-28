using C4WX1.API.Features.Shared;
using C4WX1.API.Features.SysConfig.Shared;
using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.SysConfig.Get
{
    public class GetSysConfigListSummary : EndpointSummary
    {
        public GetSysConfigListSummary()
        {
            Summary = $"Get {nameof(SysConfig)} List";
            Description = "Get a list of activities";
            Responses[200] = $"{nameof(SysConfig)} List retrieved successfully";
        }
    }

    public class GetList(
        THCC_C4WDEVContext dbContext) : Endpoint<GetListRequestDto, IEnumerable<SysConfigDto>, SysConfigMapper>
    {
        public override void Configure()
        {
            Get("sysconfig/list");
            AllowAnonymous();
            Description(b => b
                .Accepts<GetListRequestDto>()
                .Produces<IEnumerable<SysConfigDto>>()
                .ProducesProblemFE<InternalErrorResponse>(500));
            Summary(new GetSysConfigListSummary());
        }

        public override async Task HandleAsync(GetListRequestDto req, CancellationToken ct)
        {
            var pageIndex = req.PageIndex ?? 1;
            var pageSize = req.PageSize ?? 10;
            var orderBy = req.OrderBy ?? $"{nameof(Database.Models.SysConfig.ConfigName)} {GetListRequestDto.Asc}";
            var startRowIndex = Math.Max(0, (pageIndex - 1) * pageSize);
            var query = dbContext.SysConfig
                .AsQueryable();
            var order = orderBy.Split(' ');
            var sortColumn = order[0];
            var isDescending = order[1].Equals(GetListRequestDto.Desc, StringComparison.OrdinalIgnoreCase);
            query = sortColumn switch
            {
                nameof(Database.Models.SysConfig.ConfigValue) => isDescending
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
}
