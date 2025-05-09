using C4WX1.API.Features.Activity.Dtos;
using C4WX1.API.Features.Activity.Mappers;

namespace C4WX1.API.Features.Activity.Endpoints;

public class CreateActivitySummary 
    : C4WX1CreateSummary<Database.Models.Activity>
{
    public CreateActivitySummary() : base()
    {
        ExampleRequest = new CreateActivityDto
        {
            ProblemListID_FK = 1,
            DiseaseID_FK = 1,
            ActivityDetail = "Activity Detail",
            DiseaseSubInfoID_FK = 1,
            UserId = 1
        };
    }
}

public class Create(THCC_C4WDEVContext dbContext)
    : Endpoint<CreateActivityDto, int, CreateActivityMapper>
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
        await SendOkAsync(entity.ActivityID, cancellation: ct);
    }
}
