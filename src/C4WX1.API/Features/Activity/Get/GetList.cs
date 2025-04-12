using C4WX1.API.Features.Activity.Dtos;
using C4WX1.API.Features.Activity.Mappers;
using C4WX1.API.Features.Activity.Repository;
using C4WX1.API.Features.Shared.Constants;
using C4WX1.API.Features.Shared.Dtos;
using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.Activity.Get;

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
    IActivityRepository repository)
    : Endpoint<GetListDto, IEnumerable<ActivityDto>, ActivityMapper>
{
    public override void Configure()
    {
        Get("activity");
        Summary(new GetActivityListSummary());
    }

    public override async Task HandleAsync(GetListDto req, CancellationToken ct)
    {
        var pageIndex = req.PageIndex ?? 1;
        var pageSize = req.PageSize ?? 10;
        var startRowIndex = Math.Max(0, (pageIndex - 1) * pageSize);

        var orderBy = string.IsNullOrWhiteSpace(req.OrderBy)
            ? SortDirections.Default
            : req.OrderBy;
        var order = orderBy.Split(' ');
        var sortColumn = order[0];
        var isDescending = order[1].Equals(SortDirections.Default, StringComparison.OrdinalIgnoreCase);

        var query = dbContext.Activity
            .Where(x => !x.IsDeleted);
        query = sortColumn switch
        {
            "ProblemInfo" => isDescending
                ? query.OrderByDescending(x => x.ProblemListID_FKNavigation.ProblemInfo)
                : query.OrderBy(x => x.ProblemListID_FKNavigation.ProblemInfo),
            _ => isDescending
                ? query.OrderByDescending(x => x.ActivityDetail)
                : query.OrderBy(x => x.ActivityDetail)
        };

        var dtos = await query
            .Skip(startRowIndex)
            .Take(pageSize)
            .Select(x => Map.FromEntity(x))
            .ToListAsync(ct);

        if (dtos.Count <= 0)
        {
            await SendOkAsync(dtos, cancellation: ct);
            return;
        }

        var activityIds = dtos.Select(x => x.ActivityID);
        var canDeleteDict = await repository.BatchCanDeleteAsync(activityIds);
        foreach (var dto in dtos)
        {
            dto.CanDelete = canDeleteDict.TryGetValue(dto.ActivityID, out var canDelete)
                && canDelete;
        }

        await SendAsync(dtos, cancellation: ct);
    }
}
