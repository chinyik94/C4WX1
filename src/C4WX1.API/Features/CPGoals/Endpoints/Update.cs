using C4WX1.API.Features.CPGoals.Dtos;
using C4WX1.API.Features.CPGoals.Mappers;
using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.CPGoals.Endpoints;

public class UpdateCPGoalsSummary : EndpointSummary
{
    public UpdateCPGoalsSummary()
    {
        Summary = "Update CP Goals";
        Description = "Update an existing CP Goals";
        ExampleRequest = new UpdateCPGoalsDto
        {
            Id = 1,
            CPGoalsInfo = "CP Goals Info",
            DiseaseID_FK = 1,
            UserId = 1
        };
        Responses[204] = "CP Goals updated successfully";
    }
}

public class Update(THCC_C4WDEVContext dbContext)
    : EndpointWithMapper<UpdateCPGoalsDto, UpdateCPGoalsMapper>
{
    public override void Configure()
    {
        Put("cp-goals/{id}");
        Summary(new UpdateCPGoalsSummary());
    }

    public override async Task HandleAsync(UpdateCPGoalsDto req, CancellationToken ct)
    {
        var entity = await dbContext.CPGoals
            .Where(x => x.CPGoalsID == req.Id)
            .FirstOrDefaultAsync(ct);
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
