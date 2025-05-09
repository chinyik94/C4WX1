using C4WX1.API.Features.Branch.Repository;
using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.Branch.Endpoints;

public class DeleteBranchSummary 
    : C4WX1DeleteSummary<Database.Models.Branch>
{
    public DeleteBranchSummary() : base()
    {
        Responses[400] = "Branch cannot be deleted";
    }
}

public class Delete(
    THCC_C4WDEVContext dbContext,
    IBranchRepository repository)
    : Endpoint<DeleteByIdDto>
{
    public override void Configure()
    {
        Delete("branch/{id}");
        Description(b => b
            .ProducesProblemFE(400)
            .Produces(404));
        Summary(new DeleteBranchSummary());
    }

    public override async Task HandleAsync(DeleteByIdDto req, CancellationToken ct)
    {
        var canDeleteBranch = await repository.CanDeleteAsync(req.Id);
        var canDelete = await dbContext.Branch
            .Where(x => !x.IsDeleted && x.BranchID == req.Id && canDeleteBranch)
            .AnyAsync(ct);
        if (!canDelete)
        {
            ThrowError("UNABLE_DELETE");
            return;
        }

        var entity = await dbContext.Branch
            .FirstOrDefaultAsync(x => !x.IsDeleted && x.BranchID == req.Id, ct);
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
