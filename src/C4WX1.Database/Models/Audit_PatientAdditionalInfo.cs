using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_PatientAdditionalInfo
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int PatientAdditionalInfoID { get; set; }

    public bool? AICD { get; set; }

    public DateTime? AICD_InsertDate { get; set; }

    public string? AICD_InsertedBy { get; set; }

    public DateTime? AICD_ReviewDate { get; set; }

    public bool? ACP { get; set; }

    public DateTime? ACP_DoneDate { get; set; }

    public DateTime? ACP_ReviewDate { get; set; }

    public bool? DNR { get; set; }

    public bool? Pacemaker { get; set; }

    public DateTime? Pacemaker_InsertDate { get; set; }

    public string? Pacemaker_InsertedBy { get; set; }

    public DateTime? Pacemaker_ReviewDate { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public DateTime? DNR_DateInitiated { get; set; }

    public string? DNR_InitiatedBy { get; set; }

    public DateTime? DNR_DateTerminated { get; set; }

    public string? DNR_TerminatedBy { get; set; }

    public bool? CVCLine { get; set; }

    public DateTime? CVCLine_InsertDate { get; set; }

    public string? CVCLine_InsertedBy { get; set; }

    public DateTime? CVCLine_ReviewDate { get; set; }

    public bool? PICCLine { get; set; }

    public DateTime? PICCLine_InsertDate { get; set; }

    public string? PICCLine_InsertedBy { get; set; }

    public DateTime? PICCLine_ReviewDate { get; set; }

    public bool? IVLine { get; set; }

    public DateTime? IVLine_InsertDate { get; set; }

    public string? IVLine_InsertedBy { get; set; }

    public DateTime? IVLine_ReviewDate { get; set; }
}
