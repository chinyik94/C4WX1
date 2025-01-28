using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class PatientDrugAllergy
{
    public int DrugAllergyID { get; set; }

    public int? PatientID_FK { get; set; }

    public int? InitialCareAssessmentID_FK { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public bool IsDeleted { get; set; }

    public int? ReactionID_FK { get; set; }

    public int? MedicationID_FK { get; set; }

    public int? ReferID_FK { get; set; }

    public virtual InitialCareAssessment? InitialCareAssessmentID_FKNavigation { get; set; }

    public virtual ICollection<PatientDrugAllergy> InverseReferID_FKNavigation { get; set; } = new List<PatientDrugAllergy>();

    public virtual Code? MedicationID_FKNavigation { get; set; }

    public virtual Patient? PatientID_FKNavigation { get; set; }

    public virtual Code? ReactionID_FKNavigation { get; set; }

    public virtual PatientDrugAllergy? ReferID_FKNavigation { get; set; }
}
