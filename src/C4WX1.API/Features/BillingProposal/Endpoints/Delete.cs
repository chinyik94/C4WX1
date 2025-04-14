using C4WX1.API.Features.BillingProposal.Dtos;
using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.BillingProposal.Endpoints;

public class DeleteBillingProposalSummary : EndpointSummary
{
    public DeleteBillingProposalSummary()
    {
        Summary = "Delete Billing Proposal";
        Description = "Delete Billing Proposal by its ID";
        ExampleRequest = new DeleteBillingProposalDto
        {
            Id = 1,
            UserId = 1,
        };
        Responses[200] = "Billing Proposal deleted successfully";
        Responses[404] = "Billing Proposal not found";
    }
}

public class Delete(THCC_C4WDEVContext dbContext)
    : Endpoint<DeleteBillingProposalDto>
{
    public override void Configure()
    {
        Delete("billing-proposal/{id}");
        Description(b => b.Produces(404));
        Summary(new DeleteBillingProposalSummary());
    }

    public override async Task HandleAsync(DeleteBillingProposalDto req, CancellationToken ct)
    {
        var entity = await dbContext.BillingProposal
            .Where(x => !x.IsDeleted && x.BillingProposalID == req.Id)
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
