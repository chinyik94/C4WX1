using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class PatientAMT
{
    public int PatientAMTID { get; set; }

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

    public virtual CareReport? CareReportID_FKNavigation { get; set; }

    public virtual InitialCareAssessment? InitialCareAssessmentID_FKNavigation { get; set; }

    public virtual ICollection<PatientAMTAnswer> PatientAMTAnswer { get; set; } = new List<PatientAMTAnswer>();

    public virtual Patient? PatientID_FKNavigation { get; set; }

    public virtual VitalSignDetails? VitalSignDetailId_FKNavigation { get; set; }
}
