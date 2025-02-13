using C4WX1.API.Features.Activity.Dtos;
using C4WX1.API.Features.Activity.Mappers;
using C4WX1.API.Features.Activity.Sqls;
using C4WX1.API.Features.Shared;
using C4WX1.Database.Models;
using Dapper;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.Activity.Get
{
    public class GetActivityListSummary : EndpointSummary
    {
        public GetActivityListSummary()
        {
            Summary = "Get Activity List";
            Description = "Get a list of activities";
            Responses[200] = "Activity list retrieved successfully";
        }
    }

    public class GetList(
        THCC_C4WDEVContext dbContext,
        IConfiguration configuration): Endpoint<GetListRequestDto, IEnumerable<ActivityDto>, ActivityMapper>
    {
        public override void Configure()
        {
            Get("activity/list");
            AllowAnonymous();
            Description(b => b
                .Accepts<GetListRequestDto>()
                .Produces<IEnumerable<ActivityDto>>()
                .ProducesProblemFE<InternalErrorResponse>(500));
            Summary(new GetActivityListSummary());
        }

        public override async Task HandleAsync(GetListRequestDto req, CancellationToken ct)
        {
            var pageIndex = req.PageIndex ?? 1;
            var pageSize = req.PageSize ?? 10;
            var orderBy = req.OrderBy ?? $"{nameof(Database.Models.Activity.ActivityDetail)} {GetListRequestDto.Asc}";
            var startRowIndex = Math.Max(0, (pageIndex - 1) * pageSize);
            var query = dbContext.Activity
                .Where(x => !x.IsDeleted);
            var order = orderBy.Split(' ');
            var sortColumn = order[0];
            var isDescending = order[1].Equals(GetListRequestDto.Desc, StringComparison.OrdinalIgnoreCase);
            query = sortColumn switch
            {
                nameof(ProblemList.ProblemInfo) => isDescending
                    ? query.OrderByDescending(x => x.ProblemListID_FKNavigation.ProblemInfo)
                    : query.OrderBy(x => x.ProblemListID_FKNavigation.ProblemInfo),
                _ => isDescending
                    ? query.OrderByDescending(x => x.ActivityDetail)
                    : query.OrderBy(x => x.ActivityDetail)
            };

            var data = await query
                .Skip(startRowIndex)
                .Take(pageSize)
                .Select(x => Map.FromEntity(x))
                .ToListAsync(ct);

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            using var connection = new NpgsqlConnection(connectionString);
            foreach (var d in data)
            {
                d.CanDelete = await connection.QuerySingleAsync<bool>(
                    ActivitySqls.GetCanDeleteActivity,
                    new { d.ActivityID });
            }

            await SendAsync(data, cancellation: ct);
        }
    }
}
