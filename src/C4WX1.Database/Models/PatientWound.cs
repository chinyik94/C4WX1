using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class PatientWound
{
    public int PatientWoundID { get; set; }

    public int? PatientID_FK { get; set; }

    public int? InitialCareAssessmentID_FK { get; set; }

    public DateTime? OccurDate { get; set; }

    public DateTime? SeenDate { get; set; }

    public string Site { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public string? LocationOfWound { get; set; }

    public int? CareReportID_FK { get; set; }

    public string? ActionDescription { get; set; }

    public string? Remarks { get; set; }

    public string? Category { get; set; }

    public string? Stage { get; set; }

    public int? WoundStatusID_FK { get; set; }

    public string? Comments { get; set; }

    public string? Status { get; set; }

    public string? StatusRemark { get; set; }

    public string? LocationRemark { get; set; }

    public virtual CareReport? CareReportID_FKNavigation { get; set; }

    public virtual InitialCareAssessment? InitialCareAssessmentID_FKNavigation { get; set; }

    public virtual Patient? PatientID_FKNavigation { get; set; }

    public virtual ICollection<PatientWoundDraft> PatientWoundDraft { get; set; } = new List<PatientWoundDraft>();

    public virtual ICollection<PatientWoundVisit> PatientWoundVisit { get; set; } = new List<PatientWoundVisit>();

    public virtual Code? WoundStatusID_FKNavigation { get; set; }
}
