using C4WX1.API.Features.Shared.Dtos;
using C4WX1.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace C4WX1.API.Features.ExternalDoctor.Endpoints;

public class DeleteExternalDoctorSummary : EndpointSummary
{
    public DeleteExternalDoctorSummary()
    {
        Summary = "Delete external doctor";
        Description = "Delete an existing external doctor by its ID";
        Responses[200] = "External doctor deleted successfully";
        Responses[404] = "External doctor not found";
    }
}

public class Delete(THCC_C4WDEVContext dbContext)
    : Endpoint<DeleteByIdDto>
{
    public override void Configure()
    {
        Delete("/external-doctor/{id}");
        Summary(new DeleteExternalDoctorSummary());
    }

    public override async Task HandleAsync(DeleteByIdDto req, CancellationToken ct)
    {
        var entity = await dbContext.ExternalDoctor
            .Where(x => x.ExternalDoctorID == req.Id && !x.IsDeleted)
            .FirstOrDefaultAsync(ct);
        if (entity == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }
        entity.IsDeleted = true;
        entity.ModifiedDate = DateTime.Now;
        entity.ModifiedBy_FK = req.UserId;
        await dbContext.SaveChangesAsync(ct);
        await SendOkAsync(ct);
    }
}
