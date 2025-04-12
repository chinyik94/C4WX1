namespace C4WX1.API.Features.DischargeSummaryReport.Dtos;

public class CreateDischargeSummaryReportDto
{
    public int PatientID_FK { get; set; }
    public DateTime? DischargeDate { get; set; }
    public DateTime? VisitDateStart { get; set; }
    public DateTime? VisitDateEnd { get; set; }
    public int? VisitedBy_FK { get; set; }
    public string SummaryCaseNote { get; set; } = null!;
    public int? UserId { get; set; }
    public ICollection<DischargeSummaryReportAttachmentDto> AttachmentList { get; set; } = [];
}
