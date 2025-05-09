using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.Activity.Endpoints;

public class DeleteActivitySummary 
    : C4WX1DeleteSummary<Database.Models.Activity>
{
    public DeleteActivitySummary() { }
}

public class Delete(THCC_C4WDEVContext dbContext)
    : Endpoint<DeleteByIdDto>
{
    public override void Configure()
    {
        Delete("activity/{id}");
        Description(b => b.Produces(404));
        Summary(new DeleteActivitySummary());
    }

    public override async Task HandleAsync(DeleteByIdDto req, CancellationToken ct)
    {
        var entity = await dbContext.Activity
            .FirstOrDefaultAsync(a => a.ActivityID == req.Id && !a.IsDeleted, ct);
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
