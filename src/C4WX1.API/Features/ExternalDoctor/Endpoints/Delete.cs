using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.ExternalDoctor.Endpoints;

public class DeleteExternalDoctorSummary 
    : C4WX1DeleteSummary<Database.Models.ExternalDoctor>
{
    public DeleteExternalDoctorSummary() { }
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
