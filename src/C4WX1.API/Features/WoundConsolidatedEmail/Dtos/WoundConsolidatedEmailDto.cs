namespace C4WX1.API.Features.WoundConsolidatedEmail.Dtos;

public sealed class WoundConsolidatedEmailDto
{
    public int WoundConsolidatedEmailID { get; set; }
    public int PatientWoundVisitID_FK { get; set; }
    public int MailSettingsID_FK { get; set; }
    public string? PDFContent { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedDate { get; set; }
    public int CreatedBy_FK { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public int? ModifiedBy_FK { get; set; }
}
