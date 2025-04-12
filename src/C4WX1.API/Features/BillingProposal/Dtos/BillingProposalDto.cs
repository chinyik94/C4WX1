namespace C4WX1.API.Features.BillingProposal.Dtos;

public sealed class BillingProposalDto
{
    public int BillingProposalID { get; set; }
    public int PatientID_FK { get; set; }
    public string ProposalNumber { get; set; } = null!;
    public string Title { get; set; } = null!;
    public bool? SendEmail { get; set; }
    public bool? EmailPatient { get; set; }
    public string? EmailTo { get; set; }
    public string? EmailCC { get; set; }
    public string? EmailBCC { get; set; }
    public int CurrencyID_FK { get; set; }
    public string CurrencyCode { get; set; } = null!;
    public decimal TotalCost { get; set; }
    public string Status { get; set; } = null!;
    public string GroupNumber { get; set; } = null!;
    public short Version { get; set; }
    public DateTime CreatedDate { get; set; }
    public int CreatedBy_FK { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public int? ModifiedBy_FK { get; set; }
    public bool IsDeleted { get; set; }
    public string ProposalType { get; set; } = null!;
    public BillingProposalPatientDto PatientData { get; set; } = null!;
    public BillingProposalUserDto CreatedByData { get; set; } = null!;
    public BillingProposalUserDto? ModifiedByData { get; set; } = null!;
    public IEnumerable<BillingProposalServiceDto> ServiceList { get; set; } = [];
}
