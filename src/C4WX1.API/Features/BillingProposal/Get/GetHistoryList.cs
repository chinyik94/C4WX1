using C4WX1.API.Features.BillingProposal.Dtos;
using C4WX1.API.Features.BillingProposal.Extensions;
using C4WX1.API.Features.BillingProposal.Mappers;
using C4WX1.API.Features.Shared.Constants;
using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.BillingProposal.Get
{
    public class GetHistoryBillingProposalListSummary : EndpointSummary
    {
        public GetHistoryBillingProposalListSummary()
        {
            Summary = "Get History Billing Proposal List";
            Description = "Get filtered and sorted History Billing Proposal List";
            Responses[200] = "Billing Proposal List retrieved successfully";
        }
    }

    public class GetHistoryList(THCC_C4WDEVContext dbContext)
        : Endpoint<GetHistoryBillingProposalListDto, IEnumerable<BillingProposalDto>, BillingProposalMapper>
    {
        public override void Configure()
        {
            Get("billing-proposal/history");
            Summary(new GetHistoryBillingProposalListSummary());
            Description(b => b
                .Accepts<GetHistoryBillingProposalListDto>()
                .Produces<IEnumerable<BillingProposalDto>>()
                .ProducesProblemFE<InternalErrorResponse>(500));
        }

        public override async Task HandleAsync(GetHistoryBillingProposalListDto req, CancellationToken ct)
        {
            var dtos = await dbContext.BillingProposal
                .Where(x => !x.IsDeleted
                    && string.IsNullOrWhiteSpace(x.Status)
                    && x.GroupNumber == req.GroupNumber)
                .Sort(req.OrderBy)
                .Select(x => Map.FromEntity(x))
                .ToListAsync(ct);

            await SendAsync(dtos, cancellation: ct);
        }
    }
}
