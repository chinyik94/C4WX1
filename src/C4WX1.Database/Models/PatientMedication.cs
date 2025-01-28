using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class PatientMedication
{
    public int PatientMedicationID { get; set; }

    public string? Allergies { get; set; }

    public bool? SelfAdminister { get; set; }

    public bool? Compliant { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<InitialCareAssessment> InitialCareAssessment { get; set; } = new List<InitialCareAssessment>();

    public virtual ICollection<Patient> Patient { get; set; } = new List<Patient>();

    public virtual ICollection<PatientMedicationConsume> PatientMedicationConsume { get; set; } = new List<PatientMedicationConsume>();

    public virtual ICollection<PatientMedicationSupply> PatientMedicationSupply { get; set; } = new List<PatientMedicationSupply>();
}
