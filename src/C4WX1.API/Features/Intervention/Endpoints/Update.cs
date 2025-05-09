using C4WX1.API.Features.Intervention.Dtos;
using C4WX1.API.Features.Intervention.Mappers;

namespace C4WX1.API.Features.Intervention.Endpoints;

public class UpdateInterventionSummary 
    : C4WX1UpdateSummary<Database.Models.Intervention>
{
    public UpdateInterventionSummary()
    {
        ExampleRequest = new UpdateInterventionDto
        {
            Id = 1,
            InterventionInfo = "example-InterventionInfo",
            DiseaseID_FK = 1,
            UserId = 1
        };
    }
}

public class Update(THCC_C4WDEVContext dbContext)
    : EndpointWithMapper<UpdateInterventionDto, UpdateInterventionMapper>
{
    public override void Configure()
    {
        Put("intervention/{id}");
        Summary(new UpdateInterventionSummary());
    }

    public override async Task HandleAsync(UpdateInterventionDto req, CancellationToken ct)
    {
        var entity = await dbContext.Intervention
            .Where(x => x.InterventionID == req.Id)
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
