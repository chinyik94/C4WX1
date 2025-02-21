namespace C4WX1.API.Features.BillingProposal.Dtos
{
    public sealed class UpdateBillingProposalDto
    {
        public int Id { get; set; }
        public int PatientID_FK { get; set; }
        public string Title { get; set; } = null!;
        public bool? SendEmail { get; set; }
        public bool? EmailPatient { get; set; }
        public string? EmailTo { get; set; }
        public string? EmailCC { get; set; }
        public string? EmailBCC { get; set; }
        public int CurrencyID_FK { get; set; }
        public string Status { get; set; } = null!;
        public string GroupNumber { get; set; } = null!;
        public short Version { get; set; }
        public string ProposalType { get; set; } = null!;
        public int UserId { get; set; }
        public ICollection<BillingProposalServiceDto> ServiceList { get; set; } = null!;
    }
}
