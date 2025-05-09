using C4WX1.API.Features.CarePlanSubGoal.Dtos;
using C4WX1.API.Features.CarePlanSubGoal.Mappers;

namespace C4WX1.API.Features.CarePlanSubGoal.Endpoints;

public class UpdateCarePlanSubGoalSummary 
    : C4WX1UpdateSummary<Database.Models.CarePlanSubGoal>
{
    public UpdateCarePlanSubGoalSummary() : base()
    {
        ExampleRequest = new UpdateCarePlanSubGoalDto
        {
            Id = 1,
            CarePlanSubGoalName = "care plan sub goal",
            CarePlanSubID_FK = 1,
            UserId = 1
        };
    }
}

public class Update(THCC_C4WDEVContext dbContext)
    : EndpointWithMapper<UpdateCarePlanSubGoalDto, UpdateCarePlanSubGoalMapper>
{
    public override void Configure()
    {
        Put("care-plan-sub-goal/{id}");
        Description(b => b.Produces(404));
        Summary(new UpdateCarePlanSubGoalSummary());
    }

    public override async Task HandleAsync(UpdateCarePlanSubGoalDto req, CancellationToken ct)
    {
        var entity = await dbContext.CarePlanSubGoal
            .FirstOrDefaultAsync(x => x.CarePlanSubGoalID == req.Id, ct);
        if (entity == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        entity = Map.UpdateEntity(req, entity);
        await dbContext.SaveChangesAsync(ct);
        await SendNoContentAsync(ct);
    }
}
