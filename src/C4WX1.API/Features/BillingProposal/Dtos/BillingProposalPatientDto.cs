namespace C4WX1.API.Features.BillingProposal.Dtos
{
    public sealed class BillingProposalPatientDto
    {
        public int PatientID { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Photo { get; set; }
        public string? MailingAddress1 { get; set; }
        public string? MailingAddress2 { get; set; }
        public string? MailingAddress3 { get; set; }
        public string? MailingPostalCode { get; set; }
        public BillingProposalPatientProfileDto? Profile { get; set; }
    }
}
