namespace C4WX1.API.Features.BillingProposal.Dtos
{
    public sealed class UpdateBillingProposalStatusDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Status { get; set; } = null!;
    }
}
