using FastEndpoints;

namespace C4WX1.API.Features.BillingProposal.Dtos
{
    public sealed class GetBillingProposalCountDto
    {
        [QueryParam]
        public string? Keyword { get; set; }

        [QueryParam]
        public string? Status { get; set; }
    }
}
