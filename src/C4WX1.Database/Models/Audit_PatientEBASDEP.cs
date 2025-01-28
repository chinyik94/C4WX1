using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_PatientEBASDEP
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int PatientEBASDEPID { get; set; }

    public int? PatientID_FK { get; set; }

    public int? InitialCareAssessmentID_FK { get; set; }

    public string? Alertness { get; set; }

    public int? Score { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public bool IsDeleted { get; set; }

    public int? CareReportID_FK { get; set; }

    public int? VitalSignDetailId_FK { get; set; }
}
