using C4WX1.API.Features.Facility.Dtos;
using C4WX1.API.Features.Facility.Mappers;

namespace C4WX1.API.Features.Facility.Endpoints;

public class CreateFacilityByIntegrationSourceSummary : EndpointSummary
{
    public CreateFacilityByIntegrationSourceSummary()
    {
        Summary = "Create a facility by integration source";
        Description = "Create a facility by integration source";
        Responses[200] = "Facility created successfully";
    }
}

public class CreateByIntegrationSource(THCC_C4WDEVContext dbContext)
    : Endpoint<CreateFacilityByIntegrationSourceDto, int, CreateFacilityByIntegrationSourceMapper>
{
    public override void Configure()
    {
        Post("/facilities/integration-source");
        Summary(new CreateFacilityByIntegrationSourceSummary());
    }

    public override async Task HandleAsync(
        CreateFacilityByIntegrationSourceDto request, 
        CancellationToken ct)
    {
        var entity = Map.ToEntity(request);
        await dbContext.Facility.AddAsync(entity, ct);
        await dbContext.SaveChangesAsync(ct);
        await SendAsync(entity.FacilityID, cancellation: ct);
    }
}
