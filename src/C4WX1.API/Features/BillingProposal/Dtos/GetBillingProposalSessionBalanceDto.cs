using FastEndpoints;

namespace C4WX1.API.Features.BillingProposal.Dtos
{
    public sealed class GetBillingProposalSessionBalanceDto
    {
        [QueryParam]
        public int ProposalId { get; set; }

        [QueryParam]
        public int ServiceId { get; set; }

        [QueryParam]
        public DateTime EndDate { get; set; }
    }
}
