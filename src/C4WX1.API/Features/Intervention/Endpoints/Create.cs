using C4WX1.API.Features.Intervention.Dtos;
using C4WX1.API.Features.Intervention.Mappers;

namespace C4WX1.API.Features.Intervention.Endpoints;

public class CreateInterventionSummary 
    : C4WX1CreateSummary<Database.Models.Intervention>
{
    public CreateInterventionSummary()
    {
        ExampleRequest = new CreateInterventionDto
        {
            InterventionInfo = "example-InterventionInfo",
            DiseaseID_FK = 1,
            UserId = 1
        };
    }
}

public class Create(THCC_C4WDEVContext dbContext)
    : Endpoint<CreateInterventionDto, int, CreateInterventionMapper>
{
    public override void Configure()
    {
        Post("intervention");
        Summary(new CreateInterventionSummary());
    }

    public override async Task HandleAsync(CreateInterventionDto req, CancellationToken ct)
    {
        var entity = Map.ToEntity(req);
        await dbContext.Intervention.AddAsync(entity, ct);
        await dbContext.SaveChangesAsync(ct);
        await SendOkAsync(entity.InterventionID, ct);
    }
}
