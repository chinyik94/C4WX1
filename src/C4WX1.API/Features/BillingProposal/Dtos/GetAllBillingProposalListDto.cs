namespace C4WX1.API.Features.BillingProposal.Dtos;

public sealed class GetAllBillingProposalListDto
{
    [QueryParam]
    public string? Keyword { get; set; }

    [QueryParam]
    public string? Status { get; set; }

    [QueryParam]
    public string? OrderBy { get; set; }
}
