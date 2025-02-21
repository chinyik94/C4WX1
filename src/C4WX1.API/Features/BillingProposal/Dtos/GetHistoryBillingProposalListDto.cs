using FastEndpoints;

namespace C4WX1.API.Features.BillingProposal.Dtos
{
    public sealed class GetHistoryBillingProposalListDto
    {
        [QueryParam]
        public string? GroupNumber { get; set; }

        [QueryParam]
        public string? OrderBy { get; set; }
    }
}
