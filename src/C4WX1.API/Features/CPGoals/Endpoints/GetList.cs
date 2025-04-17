using C4WX1.API.Features.CPGoals.Dtos;
using C4WX1.API.Features.CPGoals.Mappers;
using C4WX1.API.Features.CPGoals.Repository;
using C4WX1.API.Features.Shared.Constants;
using C4WX1.API.Features.Shared.Dtos;
using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.CPGoals.Endpoints;

public class GetCPGoalsListSummary : EndpointSummary
{
    public GetCPGoalsListSummary()
    {
        Summary = "Get CP Goals List";
        Description = "Get a paged and sorted list of CP Goals";
        Responses[200] = "CP Goals List retrieved successfully";
    }
}

public class GetList(
    THCC_C4WDEVContext dbContext,
    ICPGoalsRepository repository)
    : Endpoint<GetListDto, IEnumerable<CPGoalsDto>, CPGoalsMapper>
{
    public override void Configure()
    {
        Get("cp-goals");
        Summary(new GetCPGoalsListSummary());
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
        var isDescending = order[1].Equals(SortDirections.Desc, StringComparison.OrdinalIgnoreCase);

        var query = dbContext.CPGoals
            .Include(x => x.DiseaseID_FKNavigation)
                .ThenInclude(x => x.SystemID_FKNavigation)
            .Where(x => !x.IsDeleted);
        query = sortColumn switch
        {
            "DiseaseName" => isDescending
                ? query.OrderByDescending(x => x.DiseaseID_FKNavigation.DiseaseName)
                : query.OrderBy(x => x.DiseaseID_FKNavigation.DiseaseName),
            _ => isDescending
                ? query.OrderByDescending(x => x.CPGoalsInfo)
                : query.OrderBy(x => x.CPGoalsInfo)
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

        var activityIds = dtos.Select(x => x.CPGoalsID).ToArray();
        var canDeleteDict = await repository.BatchCanDeleteAsync(activityIds);
        foreach (var dto in dtos)
        {
            dto.CanDelete = canDeleteDict.TryGetValue(dto.CPGoalsID, out var canDelete)
                && canDelete;
        }

        await SendAsync(dtos, cancellation: ct);
    }
}
