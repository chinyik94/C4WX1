using C4WX1.API.Features.CPGoals.Dtos;
using C4WX1.API.Features.CPGoals.Mappers;
using C4WX1.Database.Models;

namespace C4WX1.API.Features.CPGoals.Endpoints;

public class CreateCPGoalsSummary : EndpointSummary
{
    public CreateCPGoalsSummary()
    {
        Summary = "Create CP Goals";
        Description = "Create a new CP Goals";
        ExampleRequest = new CreateCPGoalsDto
        {
            CPGoalsInfo = "CP Goals Info",
            DiseaseID_FK = 1,
            UserId = 1
        };
        Responses[200] = "CP Goals created successfully";
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
