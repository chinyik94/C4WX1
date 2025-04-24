using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.DischargeSummaryReport.Dtos;

public sealed class UpdateDischargeSummaryReportDto : UpdateDto
{
    public int PatientID_FK { get; set; }
    public DateTime? DischargeDate { get; set; }
    public DateTime? VisitDateStart { get; set; }
    public DateTime? VisitDateEnd { get; set; }
    public int? VisitedBy_FK { get; set; }
    public string SummaryCaseNote { get; set; } = null!;
    public ICollection<DischargeSummaryReportAttachmentDto> AttachmentList { get; set; } = [];
}
