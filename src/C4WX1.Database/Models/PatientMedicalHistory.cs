using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class PatientMedicalHistory
{
    public int PatientMedicalHistoryID { get; set; }

    public int? PatientID_FK { get; set; }

    public int? InitialCareAssessmentID_FK { get; set; }

    public int? ClinicianID_FK { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public bool IsDeleted { get; set; }

    public int? MedicalStatusID_FK { get; set; }

    public virtual PatientClinician? ClinicianID_FKNavigation { get; set; }

    public virtual Code? MedicalStatusID_FKNavigation { get; set; }

    public virtual Patient? PatientID_FKNavigation { get; set; }
}
