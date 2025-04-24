using C4WX1.API.Features.Facility.Dtos;
using C4WX1.API.Features.Facility.Mappers;
using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.Facility.Endpoints;

public class UpdateFacilitySummary : EndpointSummary
{
    public UpdateFacilitySummary()
    {
        Summary = "Update facility";
        Description = "Update an existing facility by its ID";
        Responses[204] = "Facility updated successfully";
        Responses[404] = "Facility not found";
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
