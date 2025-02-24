using C4WX1.API.Features.CarePlanSubGoal.Dtos;
using C4WX1.API.Features.CarePlanSubGoal.Mappers;
using C4WX1.API.Features.CarePlanSubGoal.Repository;
using C4WX1.API.Features.Shared.Dtos;
using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.CarePlanSubGoal.Get
{
    public class GetCarePlanSubGoalByIdSummary : EndpointSummary
    {
        public GetCarePlanSubGoalByIdSummary()
        {
            Summary = "Get Care Plan Sub Goal";
            Description = "Get a Care Plan Sub Goal by its ID";
            Responses[200] = "Care Plan Sub Goal retrieved successfully";
            Responses[404] = "Care Plan Sub Goal not found";
        }
    }

    public class GetById(
        THCC_C4WDEVContext dbContext,
        ICarePlanSubGoalRepository repository)
        : Endpoint<GetByIdDto, CarePlanSubGoalDto, CarePlanSubGoalMapper>
    {
        public override void Configure()
        {
            Get("care-plan-sub-goal/{id}");
            Summary(new GetCarePlanSubGoalByIdSummary());
            Description(b => b
                .Accepts<GetByIdDto>()
                .Produces<CarePlanSubGoalDto>()
                .Produces(404)
                .ProducesProblemFE<InternalErrorResponse>(500));
        }

        public override async Task HandleAsync(GetByIdDto req, CancellationToken ct)
        {
            var dto = await dbContext.CarePlanSubGoal
                .Where(x => !(x.IsDeleted ?? false) && x.CarePlanSubGoalID == req.Id)
                .Select(x => Map.FromEntity(x))
                .FirstOrDefaultAsync(ct);
            if (dto == null)
            {
                await SendNotFoundAsync(ct);
                return;
            }

            dto.CanDelete = await repository.CanDeleteAsync(req.Id);
            await SendOkAsync(dto, cancellation: ct);
        }
    }
}
