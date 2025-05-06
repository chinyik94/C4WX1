using C4WX1.API.Features.Facility.Dtos;
using C4WX1.API.Features.Facility.Mappers;
using C4WX1.Database.Models;

namespace C4WX1.API.Features.Facility.Endpoints;

public class CreateFacilitySummary : EndpointSummary
{
    public CreateFacilitySummary()
    {
        Summary = "Create a new facility";
        Description = "Create a new facility";
        Responses[200] = "Facility created successfully";
    }
}

public class Create(THCC_C4WDEVContext dbContext)
    : Endpoint<CreateFacilityDto, int, CreateFacilityMapper>
{
    public override void Configure()
    {
        Post("/facilities");
        Summary(new CreateFacilitySummary());
    }

    public override async Task HandleAsync(CreateFacilityDto request, CancellationToken ct)
    {
        var entity = Map.ToEntity(request);
        await dbContext.Facility.AddAsync(entity, ct);
        await dbContext.SaveChangesAsync(ct);
        await SendAsync(entity.FacilityID, cancellation: ct);
    }
}
