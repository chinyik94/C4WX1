using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class DischargeSummaryReportAttachment
{
    public int DischargeSummaryReportAttachmentID { get; set; }

    public int DischargeSummaryReportID_FK { get; set; }

    public string? Filename { get; set; }

    public string? Physical { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public bool IsDeleted { get; set; }

    public virtual DischargeSummaryReport DischargeSummaryReportID_FKNavigation { get; set; } = null!;
}
