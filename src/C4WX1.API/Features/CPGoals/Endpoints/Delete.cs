﻿using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.CPGoals.Endpoints;

public class DeleteCPGoalsSummary 
    : C4WX1DeleteSummary<Database.Models.CPGoals>
{
    public DeleteCPGoalsSummary() { }
}

public class Delete(THCC_C4WDEVContext dbContext)
    : Endpoint<DeleteByIdDto>
{
    public override void Configure()
    {
        Delete("cp-goals/{id}");
        Summary(new DeleteCPGoalsSummary());
    }

    public override async Task HandleAsync(DeleteByIdDto req, CancellationToken ct)
    {
        var entity = await dbContext.CPGoals
            .Where(x => x.CPGoalsID == req.Id && !x.IsDeleted)
            .FirstOrDefaultAsync(ct);
        if (entity == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }
        entity.IsDeleted = true;
        entity.ModifiedDate = DateTime.Now;
        entity.ModifiedBy_FK = req.UserId;
        await dbContext.SaveChangesAsync(ct);
        await SendNoContentAsync(ct);
    }
}
