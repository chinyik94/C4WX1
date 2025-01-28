using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class TeleconsultationReport
{
    public int TeleReportID { get; set; }

    public int MediaType { get; set; }

    public int TaskID_FK { get; set; }

    public int PatientID_FK { get; set; }

    public string Memo { get; set; } = null!;

    public string? Status { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public DateOnly? ModifiedDate { get; set; }
}
