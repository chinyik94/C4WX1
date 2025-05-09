using C4WX1.API.Features.Facility.Dtos;
using C4WX1.API.Features.Facility.Mappers;

namespace C4WX1.API.Features.Facility.Endpoints;

public class UpdateFacilityByIntegrationSourceSummary : EndpointSummary
{
    public UpdateFacilityByIntegrationSourceSummary()
    {
        Description = "Update facility by integration source";
        Summary = "Update facility by integration source";
        Responses[200] = "Facility updated successfully";
        Responses[404] = "Facility not found";
    }
}

public class UpdateByIntegrationSource(THCC_C4WDEVContext dbContext)
    : EndpointWithMapper<UpdateFacilityByIntegrationSourceDto, UpdateFacilityByIntegrationSourceMapper>
{
    public override void Configure()
    {
        Put("/facility/integration-source/{id}");
        Summary(new UpdateFacilityByIntegrationSourceSummary());
    }

    public override async Task HandleAsync(UpdateFacilityByIntegrationSourceDto req, CancellationToken ct)
    {
        var entity = await dbContext.Facility
            .Where(x => !x.IsDeleted 
                && x._id == req.C_Id
                && x.IntegrationSource == req.IntegrationSource)
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
