using C4WX1.API.Features.Facility.Dtos;
using C4WX1.API.Features.Facility.Mappers;

namespace C4WX1.API.Features.Facility.Endpoints;

public class CreateFacilitySummary 
    : C4WX1CreateSummary<Database.Models.Facility>
{
    public CreateFacilitySummary() : base()
    {
        ExampleRequest = new CreateFacilityDto
        {
            FacilityName = "example-FacilityName",
            OrganizationID_FK = 1,
            UserId = 1
        };
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
