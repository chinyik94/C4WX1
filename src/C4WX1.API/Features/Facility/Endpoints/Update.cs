using C4WX1.API.Features.Facility.Dtos;
using C4WX1.API.Features.Facility.Mappers;

namespace C4WX1.API.Features.Facility.Endpoints;

public class UpdateFacilitySummary 
    : C4WX1UpdateSummary<Database.Models.Facility>
{
    public UpdateFacilitySummary() : base()
    {
        ExampleRequest = new UpdateFacilityDto
        {
            Id = 1,
            FacilityName = "example-FacilityName",
            OrganizationID_FK = 1,
            UserId = 1
        };
    }
}

public class Update(THCC_C4WDEVContext dbContext)
    : EndpointWithMapper<UpdateFacilityDto, UpdateFacilityMapper>
{
    public override void Configure()
    {
        Put("/facility/{id}");
        Summary(new UpdateFacilitySummary());
    }

    public override async Task HandleAsync(UpdateFacilityDto req, CancellationToken ct)
    {
        var entity = await dbContext.Facility
            .Where(x => !x.IsDeleted && x.FacilityID == req.Id)
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
