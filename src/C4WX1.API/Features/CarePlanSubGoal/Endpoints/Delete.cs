using C4WX1.API.Features.Shared.Dtos;
using C4WX1.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace C4WX1.API.Features.CarePlanSubGoal.Endpoints;

public class DeleteCarePlanSubGoalSummary : EndpointSummary
{
    public DeleteCarePlanSubGoalSummary()
    {
        Summary = "Delete Care Plan Sub Goal";
        Description = "Delete a Care Plan Sub Goal by its ID";
        Responses[200] = "Care Plan Sub Goal deleted successfully";
        Responses[404] = "Care Plan Sub Goal not found";
    }
}

public class Delete(THCC_C4WDEVContext dbContext)
    : Endpoint<DeleteByIdDto>
{
    public override void Configure()
    {
        Delete("care-plan-sub-goal/{id}");
        Description(b => b.Produces(404));
        Summary(new DeleteCarePlanSubGoalSummary());
    }

    public override async Task HandleAsync(DeleteByIdDto req, CancellationToken ct)
    {
        var entity = await dbContext.CarePlanSubGoal
            .Where(x => !(x.IsDeleted ?? false) && x.CarePlanSubGoalID == req.Id)
            .FirstOrDefaultAsync(ct);
        if (entity == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        entity.IsDeleted = true;
        entity.ModifiedBy_FK = req.UserId;
        entity.ModifiedDate = DateTime.Now;

        await dbContext.SaveChangesAsync(ct);
        await SendNoContentAsync(ct);
    }
}
