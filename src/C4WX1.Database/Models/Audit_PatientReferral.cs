using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_PatientReferral
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int PatientReferralID { get; set; }

    public int? PrimaryClinicianID_FK { get; set; }

    public int? SecondaryClinicianID_FK { get; set; }

    public bool? PatientAwareDiagnose { get; set; }

    public bool? FamilyAwareDiagnose { get; set; }

    public bool? PatientAwarePrognosis { get; set; }

    public bool? FamilyAwarePrognosis { get; set; }

    public string? PatientAwareDiagnoseReason { get; set; }

    public string? FamilyAwareDiagnoseReason { get; set; }

    public string? PatientAwarePrognosisReason { get; set; }

    public string? FamilyAwarePrognosisReason { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public int? PrimaryNurseID_FK { get; set; }

    public int? SecondaryNurseID_FK { get; set; }
}
