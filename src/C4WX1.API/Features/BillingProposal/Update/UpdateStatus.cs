using C4WX1.API.Features.BillingProposal.Constants;
using C4WX1.API.Features.BillingProposal.Dtos;
using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.BillingProposal.Update
{
    public class UpdateBillingProposalStatusSummary : EndpointSummary
    {
        public UpdateBillingProposalStatusSummary()
        {
            Summary = "Update Billing Proposal Status";
            Description = "Update Billing Proposal Status by its ID";
            ExampleRequest = new UpdateBillingProposalStatusDto
            {
                Id = 1,
                UserId = 1,
                Status = "Success"
            };
            Responses[200] = "Billing Proposal Status updated successfully";
            Responses[400] = "Billing Proposal not found";
            Responses[404] = "Billing Proposal Status invalid";
        }
    }

    public class UpdateStatus(THCC_C4WDEVContext dbContext)
        : Endpoint<UpdateBillingProposalStatusDto>
    {
        private readonly string[] _acceptedStatuses = [
            BillingProposalStatuses.Success,
            BillingProposalStatuses.Fail
            ];

        public override void Configure()
        {
            Put("billing-proposal/{id}/status");
            Summary(new UpdateBillingProposalStatusSummary());
            Description(b => b
                .Accepts<UpdateBillingProposalStatusDto>()
                .Produces(400)
                .Produces(404)
                .ProducesProblemFE<InternalErrorResponse>(500));
        }

        public override async Task HandleAsync(UpdateBillingProposalStatusDto req, CancellationToken ct)
        {
            if (!_acceptedStatuses.Contains(req.Status))
            {
                ThrowError("Invalid Billing Proposal Status");
                return;
            }

            var entity = await dbContext.BillingProposal
                .Where(x => !x.IsDeleted && x.BillingProposalID == req.Id)
                .FirstOrDefaultAsync(ct);
            if (entity == null)
            {
                await SendNotFoundAsync(ct);
                return;
            }

            entity.Status = req.Status;
            entity.ModifiedBy_FK = req.UserId;
            entity.ModifiedDate = DateTime.Now;
            await dbContext.SaveChangesAsync(ct);
            await SendNoContentAsync(ct);
        }
    }
}
