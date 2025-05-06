using C4WX1.API.Features.Shared.Dtos;
using C4WX1.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace C4WX1.API.Features.Facility.Endpoints;

public class DeleteFacilitySummary : EndpointSummary
{
    public DeleteFacilitySummary()
    {
        Summary = "Delete a facility";
        Description = "Delete an existing facility by its ID";
        Responses[204] = "Facility deleted successfully";
        Responses[404] = "Facility not found";
    }
}

public class Delete(THCC_C4WDEVContext dbContext)
    : Endpoint<DeleteByIdDto>
{
    public override void Configure()
    {
        Delete("/facility/{id}");
        Summary(new DeleteFacilitySummary());
    }

    public override async Task HandleAsync(DeleteByIdDto req, CancellationToken ct)
    {
        var entity = await dbContext.Facility
            .Where(x => !x.IsDeleted && x.FacilityID == req.Id)
            .FirstOrDefaultAsync(ct);
        if (entity == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }
        entity.IsDeleted = true;
        entity.ModifiedBy_FK = req.UserId;
        entity.ModifiedDate = DateTime.Now;
        await dbContext.SaveChangesAsync(ct);
        await SendNoContentAsync(ct);
    }
}
