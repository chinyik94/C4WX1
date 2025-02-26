using C4WX1.API.Features.CarePlanSubGoal.Dtos;
using C4WX1.API.Features.CarePlanSubGoal.Mappers;
using C4WX1.Database.Models;
using FastEndpoints;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.CarePlanSubGoal.Create
{
    public class CreateCarePlanSubGoalSummary : EndpointSummary
    {
        public CreateCarePlanSubGoalSummary()
        {
            Summary = "Create Care Plan Sub Goal";
            Description = "Create a new Care Plan Sub Goal";
            ExampleRequest = new CreateCarePlanSubGoalDto
            {
                CarePlanSubGoalName = "care plan sub goal",
                CarePlanSubID_FK = 1,
                UserId = 1
            };
            Responses[204] = "Care Plan Sub Goal created successfully";
        }
    }

    public class Create(THCC_C4WDEVContext dbContext)
        : EndpointWithMapper<CreateCarePlanSubGoalDto, CreateCarePlanSubGoalMapper>
    {
        public override void Configure()
        {
            Post("care-plan-sub-goal");
            Summary(new CreateCarePlanSubGoalSummary());
        }

        public override async Task HandleAsync(CreateCarePlanSubGoalDto req, CancellationToken ct)
        {
            var entity = Map.ToEntity(req);
            dbContext.CarePlanSubGoal.Add(entity);
            await dbContext.SaveChangesAsync(ct);
            await SendNoContentAsync(ct);
        }
    }
}
