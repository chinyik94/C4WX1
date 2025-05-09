using C4WX1.API.Features.CPGoals.Dtos;
using C4WX1.API.Features.CPGoals.Mappers;

namespace C4WX1.API.Features.CPGoals.Endpoints;

public class CreateCPGoalsSummary 
    : C4WX1CreateSummary<Database.Models.CPGoals>
{
    public CreateCPGoalsSummary() : base()
    {
        ExampleRequest = new CreateCPGoalsDto
        {
            CPGoalsInfo = "CP Goals Info",
            DiseaseID_FK = 1,
            UserId = 1
        };
    }
}

public class Create(THCC_C4WDEVContext dbContext)
    : Endpoint<CreateCPGoalsDto, int, CreateCPGoalsMapper>
{
    public override void Configure()
    {
        Post("cp-goals");
        Summary(new CreateCPGoalsSummary());
    }

    public override async Task HandleAsync(CreateCPGoalsDto req, CancellationToken ct)
    {
        var entity = Map.ToEntity(req);
        dbContext.CPGoals.Add(entity);
        await dbContext.SaveChangesAsync(ct);
        await SendOkAsync(entity.CPGoalsID, cancellation: ct);
    }
}
