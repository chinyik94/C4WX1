using C4WX1.API.Features.Shared.Dtos;
using FastEndpoints;

namespace C4WX1.API.Features.BillingProposal.Dtos;

public sealed class GetBillingProposalListDto : GetListDto
{
    [QueryParam]
    public string? Keyword { get; set; }

    [QueryParam]
    public string? Status { get; set; }
}
