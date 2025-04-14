using C4WX1.API.Features.Activity.Dtos;
using C4WX1.API.Features.Activity.Mappers;
using C4WX1.Database.Models;
using FastEndpoints;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.Activity.Endpoints;

public class CreateActivitySummary : EndpointSummary
{
    public CreateActivitySummary()
    {
        Summary = "Create Activity";
        Description = "Create a new Activity";
        ExampleRequest = new CreateActivityDto
        {
            ProblemListID_FK = 1,
            DiseaseID_FK = 1,
            ActivityDetail = "Activity Detail",
            DiseaseSubInfoID_FK = 1,
            UserId = 1
        };
        Responses[204] = "Activity created successfully";
    }
}

public class Create(THCC_C4WDEVContext dbContext)
    : EndpointWithMapper<CreateActivityDto, CreateActivityMapper>
{
    public override void Configure()
    {
        Post("activity");
        Summary(new CreateActivitySummary());
    }

    public override async Task HandleAsync(CreateActivityDto req, CancellationToken ct)
    {
        var entity = Map.ToEntity(req);
        dbContext.Activity.Add(entity);
        await dbContext.SaveChangesAsync(ct);
        await SendNoContentAsync(ct);
    }
}
