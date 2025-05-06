using C4WX1.API.Features.CarePlanSubGoal.Dtos;
using C4WX1.API.Features.CarePlanSubGoal.Extensions;
using C4WX1.API.Features.CarePlanSubGoal.Mappers;
using C4WX1.API.Features.CarePlanSubGoal.Repository;
using C4WX1.API.Features.Shared.Constants;
using C4WX1.API.Features.Shared.Dtos;
using C4WX1.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace C4WX1.API.Features.CarePlanSubGoal.Endpoints;

public class GetCarePlanSubGoalListSummary : EndpointSummary
{
    public GetCarePlanSubGoalListSummary()
    {
        Summary = "Get Care Plan Sub Goal List";
        Description = "Get a paged and sorted Care Plan Sub Goal List";
        Responses[200] = "Care Plan Sub Goal List retrieved successfully";
    }
}

public class GetList(
    THCC_C4WDEVContext dbContext,
    ICarePlanSubGoalRepository repository)
    : Endpoint<GetListDto, IEnumerable<CarePlanSubGoalDto>, CarePlanSubGoalMapper>
{
    public override void Configure()
    {
        Get("care-plan-sub-goal");
        Summary(new GetCarePlanSubGoalListSummary());
    }

    public override async Task HandleAsync(GetListDto req, CancellationToken ct)
    {
        var pageIndex = req.PageIndex ?? PaginationDefaults.Index;
        var pageSize = req.PageSize ?? PaginationDefaults.Size;
        var startRowIndex = Math.Max(0, (pageIndex - 1) * pageSize);

        var dtos = await dbContext.CarePlanSubGoal
            .Where(x => !(x.IsDeleted ?? false))
            .Sort(req.OrderBy)
            .Skip(startRowIndex)
            .Take(pageSize)
            .Select(x => Map.FromEntity(x))
            .ToListAsync(ct);

        var ids = dtos.Select(x => x.CarePlanSubGoalID).ToArray();
        var canDeleteDict = await repository.BatchCanDeleteAsync(ids);
        foreach (var dto in dtos)
        {
            dto.CanDelete = canDeleteDict.TryGetValue(dto.CarePlanSubGoalID, out var canDelete)
                && canDelete;
        }

        await SendOkAsync(dtos, cancellation: ct);
    }
}
