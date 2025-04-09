namespace C4WX1.API.Features.DischargeSummaryReport.Dtos
{
    public class DischargeSummaryReportDto
    {
        public int DischargeSummaryReportID { get; set; }
        public int PatientID_FK { get; set; }
        public string Status { get; set; } = null!;
        public DateTime? DischargeDate { get; set; }
        public DateTime? VisitDateStart { get; set; }
        public DateTime? VisitDateEnd { get; set; }
        public int? VisitedBy_FK { get; set; }
        public string SummaryCaseNote { get; set; } = null!;
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy_FK { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy_FK { get; set; }
        public bool IsDeleted { get; set; }
        public DischargeSummaryReportUserDto? CreatedBy { get; set; }
        public DischargeSummaryReportUserDto? ModifiedBy { get; set; }
        public ICollection<DischargeSummaryReportAttachmentDto> AttachmentList { get; set; } = [];
    }
}
