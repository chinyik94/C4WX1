using C4WX1.API.Features.CPGoals.Dtos;
using C4WX1.API.Features.CPGoals.Mappers;

namespace C4WX1.API.Features.CPGoals.Endpoints;

public class UpdateCPGoalsSummary 
    : C4WX1UpdateSummary<Database.Models.CPGoals>
{
    public UpdateCPGoalsSummary() : base()
    {
        ExampleRequest = new UpdateCPGoalsDto
        {
            Id = 1,
            CPGoalsInfo = "CP Goals Info",
            DiseaseID_FK = 1,
            UserId = 1
        };
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
