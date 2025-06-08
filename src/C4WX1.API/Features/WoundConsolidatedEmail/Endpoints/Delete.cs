using C4WX1.API.Features.Shared.Dtos;
using C4WX1.API.Features.WoundConsolidatedEmail.Dtos;

namespace C4WX1.API.Features.WoundConsolidatedEmail.Endpoints;

public class DeleteWoundConsolidatedEmailSummary
    : C4WX1DeleteSummary<Database.Models.WoundConsolidatedEmail>
{

}

public class Delete(THCC_C4WDEVContext dbContext)
    : Endpoint<DeleteWoundConsolidatedEmailDto>
{
    public override void Configure()
    {
        Delete("wound-consolidated-email/{id}");
        Summary(new DeleteWoundConsolidatedEmailSummary());
    }

    public override async Task HandleAsync(DeleteWoundConsolidatedEmailDto req, CancellationToken ct)
    {
        var entity = await dbContext.WoundConsolidatedEmail
            .Where(x => !x.IsDeleted
                && x.WoundConsolidatedEmailID == req.Id)
            .FirstOrDefaultAsync(ct);
        if (entity == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }
        entity.IsDeleted = true;
        entity.ModifiedDate = DateTime.Now;
        entity.ModifiedBy_FK = req.Id;
        await dbContext.SaveChangesAsync(ct);
        await SendNoContentAsync(ct);
    }
}
