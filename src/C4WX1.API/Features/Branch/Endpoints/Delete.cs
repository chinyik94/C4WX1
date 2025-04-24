using C4WX1.API.Features.Branch.Repository;
using C4WX1.API.Features.Shared.Dtos;
using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.Branch.Endpoints;

public class DeleteBranchSummary : EndpointSummary
{
    public DeleteBranchSummary()
    {
        Summary = "Delete Branch";
        Description = "Delete an existing Branch by its ID";
        ExampleRequest = new DeleteByIdDto
        {
            Id = 1,
            UserId = 1
        };
        Responses[204] = "Branch deleted successfully";
        Responses[400] = "Branch cannot be deleted";
        Responses[404] = "Branch not found";
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
        var canDeleteBranch = await repository.CanDeleteBranchAsync(req.Id);
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
