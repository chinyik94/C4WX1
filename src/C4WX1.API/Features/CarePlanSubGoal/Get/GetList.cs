using C4WX1.API.Features.CarePlanSubGoal.Dtos;
using C4WX1.API.Features.CarePlanSubGoal.Extensions;
using C4WX1.API.Features.CarePlanSubGoal.Mappers;
using C4WX1.API.Features.CarePlanSubGoal.Repository;
using C4WX1.API.Features.Shared.Dtos;
using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.CarePlanSubGoal.Get
{
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
            Description(b => b
                .Accepts<GetListDto>()
                .Produces<IEnumerable<CarePlanSubGoalDto>>()
                .ProducesProblemFE<InternalErrorResponse>(500));
        }

        public override async Task HandleAsync(GetListDto req, CancellationToken ct)
        {
            var pageIndex = req.PageIndex ?? 1;
            var pageSize = req.PageSize ?? 10;
            var startRowIndex = Math.Max(0, (pageIndex - 1) * pageSize);

            var dtos = await dbContext.CarePlanSubGoal
                .Where(x => !(x.IsDeleted ?? false))
                .Sort(req.OrderBy)
                .Take(startRowIndex)
                .Skip(pageSize)
                .Select(x => Map.FromEntity(x))
                .ToListAsync(ct);

            var ids = dtos.Select(x => x.CarePlanSubGoalID);
            var canDeleteDict = await repository.BatchCanDeleteAsync(ids);
            foreach (var dto in dtos)
            {
                dto.CanDelete = canDeleteDict.TryGetValue(dto.CarePlanSubGoalID, out var canDelete)
                    && canDelete;
            }

            await SendOkAsync(dtos, cancellation: ct);
        }
    }
}
