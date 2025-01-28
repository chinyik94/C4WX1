using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class DischargeSummaryReport
{
    public int DischargeSummaryReportId { get; set; }

    public int PatientID_FK { get; set; }

    public string Status { get; set; } = null!;

    public DateTime? DischargeDate { get; set; }

    public DateTime? VisitDateStart { get; set; }

    public DateTime? VisitDateEnd { get; set; }

    public int? VisitedBy_FK { get; set; }

    public string? SummaryCaseNote { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<DischargeSummaryReportAttachment> DischargeSummaryReportAttachment { get; set; } = new List<DischargeSummaryReportAttachment>();
}
