namespace C4WX1.API.Features.BillingProposal.Dtos;

public sealed class BillingProposalUserDto
{
    public int UserId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? Photo { get; set; }
    public string Email { get; set; } = null!;
}
