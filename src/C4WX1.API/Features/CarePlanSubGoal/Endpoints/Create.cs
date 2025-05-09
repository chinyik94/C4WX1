using C4WX1.API.Features.CarePlanSubGoal.Dtos;
using C4WX1.API.Features.CarePlanSubGoal.Mappers;

namespace C4WX1.API.Features.CarePlanSubGoal.Endpoints;

public class CreateCarePlanSubGoalSummary 
    : C4WX1CreateSummary<Database.Models.CarePlanSubGoal>
{
    public CreateCarePlanSubGoalSummary() : base()
    {
        ExampleRequest = new CreateCarePlanSubGoalDto
        {
            CarePlanSubGoalName = "care plan sub goal",
            CarePlanSubID_FK = 1,
            UserId = 1
        };
    }
}

public class Create(THCC_C4WDEVContext dbContext)
    : Endpoint<CreateCarePlanSubGoalDto, int, CreateCarePlanSubGoalMapper>
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
        await SendOkAsync(entity.CarePlanSubGoalID, cancellation: ct);
    }
}
