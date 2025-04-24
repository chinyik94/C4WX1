using C4WX1.API.Features.CarePlanSubGoal.Dtos;
using C4WX1.API.Features.CarePlanSubGoal.Mappers;
using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.CarePlanSubGoal.Endpoints;

public class UpdateCarePlanSubGoalSummary : EndpointSummary
{
    public UpdateCarePlanSubGoalSummary()
    {
        Summary = "Update Care Plan Sub Goal";
        Description = "Update a new Care Plan Sub Goal";
        ExampleRequest = new UpdateCarePlanSubGoalDto
        {
            Id = 1,
            CarePlanSubGoalName = "care plan sub goal",
            CarePlanSubID_FK = 1,
            UserId = 1
        };
        Responses[204] = "Care Plan Sub Goal updated successfully";
        Responses[404] = "Care Plan Sub Goal not found";
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
