﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class VitalSigns
{
    public int id { get; set; }

    public int patientId { get; set; }

    public string source { get; set; } = null!;

    public int icaId { get; set; }

    public bool isDeleted { get; set; }

    public int? createdBy { get; set; }

    public DateTime createdDate { get; set; }

    public int? updatedBy { get; set; }

    public DateTime? updatedDate { get; set; }

    public virtual ICollection<CareReport> CareReport { get; set; } = new List<CareReport>();

    public virtual ICollection<InitialCareAssessment> InitialCareAssessment { get; set; } = new List<InitialCareAssessment>();

    public virtual ICollection<PatientWoundVisit> PatientWoundVisit { get; set; } = new List<PatientWoundVisit>();

    public virtual ICollection<VitalSignDetails> VitalSignDetails { get; set; } = new List<VitalSignDetails>();

    public virtual Patient patient { get; set; } = null!;
}
