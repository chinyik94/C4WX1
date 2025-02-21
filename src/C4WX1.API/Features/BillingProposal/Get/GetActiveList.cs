using C4WX1.API.Features.BillingProposal.Dtos;
using C4WX1.API.Features.BillingProposal.Mappers;
using C4WX1.API.Features.Shared.Constants;
using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.BillingProposal.Get
{
    public class GetActiveBillingProposalListSummary : EndpointSummary
    {
        public GetActiveBillingProposalListSummary()
        {
            Summary = "Get Active Billing Proposal List";
            Description = "Get filtered and sorted Active Billing Proposal List by PatientID";
            Responses[200] = "Billing Proposal List retrieved successfully";
        }
    }

    public class GetActiveList(THCC_C4WDEVContext dbContext)
        : Endpoint<GetActiveBillingProposalListDto, IEnumerable<BillingProposalDto>, BillingProposalMapper>
    {
        public override void Configure()
        {
            Get("billing-proposal/active/{patientId}");
            Summary(new GetActiveBillingProposalListSummary());
            Description(b => b.
                Accepts<GetActiveBillingProposalListDto>()
                .Produces<IEnumerable<BillingProposalDto>>()
                .ProducesProblemFE<InternalErrorResponse>(500));
        }

        public override async Task HandleAsync(GetActiveBillingProposalListDto req, CancellationToken ct)
        {
            var dtos = await dbContext.BillingProposal
                .Where(x => !x.IsDeleted
                    && x.PatientID_FK == req.PatientId
                    && x.Status == Statuses.Success)
                .OrderBy(x => x.Title)
                .Select(x => Map.FromEntity(x))
                .ToListAsync(ct);

            await SendOkAsync(dtos, cancellation: ct);
        }
    }
}
