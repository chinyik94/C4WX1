using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class PatientOtherAllergy
{
    public int OtherAllergyID { get; set; }

    public int? PatientID_FK { get; set; }

    public int? InitialCareAssessmentID_FK { get; set; }

    public int? ReactionID_FK { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public bool IsDeleted { get; set; }

    public int? DescriptionID_FK { get; set; }

    public string? OtherDescription { get; set; }

    public int? ReferID_FK { get; set; }

    public virtual Code? DescriptionID_FKNavigation { get; set; }

    public virtual InitialCareAssessment? InitialCareAssessmentID_FKNavigation { get; set; }

    public virtual ICollection<PatientOtherAllergy> InverseReferID_FKNavigation { get; set; } = new List<PatientOtherAllergy>();

    public virtual Patient? PatientID_FKNavigation { get; set; }

    public virtual Code? ReactionID_FKNavigation { get; set; }

    public virtual PatientOtherAllergy? ReferID_FKNavigation { get; set; }
}
