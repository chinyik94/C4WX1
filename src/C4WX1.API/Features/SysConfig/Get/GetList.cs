using C4WX1.API.Features.Shared;
using C4WX1.API.Features.SysConfig.Dtos;
using C4WX1.API.Features.SysConfig.Mappers;
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
            Summary = "Get SysConfig List";
            Description = "Get a filtered, paged and sorted list of SysConfigs";
            Responses[200] = "SysConfig List retrieved successfully";
        }
    }

    public class GetList(
        THCC_C4WDEVContext dbContext) : Endpoint<GetSysConfigListDto, IEnumerable<SysConfigDto>, SysConfigGetMapper>
    {
        public override void Configure()
        {
            Get("sysconfig/list");
            AllowAnonymous();
            Description(b => b
                .Accepts<GetSysConfigListDto>()
                .Produces<IEnumerable<SysConfigDto>>()
                .ProducesProblemFE<InternalErrorResponse>(500));
            Summary(new GetSysConfigListSummary());
        }

        public override async Task HandleAsync(GetSysConfigListDto req, CancellationToken ct)
        {
            var pageIndex = req.PageIndex ?? 1;
            var pageSize = req.PageSize ?? 10;
            var orderBy = req.OrderBy ?? $"{nameof(Database.Models.SysConfig.ConfigName)} {GetListRequestDto.Asc}";
            var startRowIndex = Math.Max(0, (pageIndex - 1) * pageSize);
            var query = dbContext.SysConfig
                .AsQueryable();
            if (!string.IsNullOrWhiteSpace(req.ConfigName))
            {
                query = query.Where(x => x.ConfigName == req.ConfigName);
            }
            if (!string.IsNullOrWhiteSpace(req.ConfigValue))
            {
                query = query.Where(x => x.ConfigValue == req.ConfigValue);
            }

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
