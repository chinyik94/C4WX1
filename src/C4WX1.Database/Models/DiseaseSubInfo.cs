﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class DiseaseSubInfo
{
    public int DiseaseSubInfoID { get; set; }

    public string DiseaseSubInfo1 { get; set; } = null!;

    public int DiseaseID_FK { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public virtual Disease DiseaseID_FKNavigation { get; set; } = null!;

    public virtual ICollection<PatientClinician> PatientClinician { get; set; } = new List<PatientClinician>();

    public virtual ICollection<PatientFamilyHistory> PatientFamilyHistory { get; set; } = new List<PatientFamilyHistory>();

    public virtual ICollection<PatientMedicationConsume> PatientMedicationConsume { get; set; } = new List<PatientMedicationConsume>();
}
