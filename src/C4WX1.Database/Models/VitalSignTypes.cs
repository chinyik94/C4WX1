﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class VitalSignTypes
{
    public int id { get; set; }

    public string name { get; set; } = null!;

    public bool isDeleted { get; set; }

    public int? createdBy { get; set; }

    public DateTime createdDate { get; set; }

    public int? updatedBy { get; set; }

    public DateTime? updatedDate { get; set; }

    public virtual ICollection<DiseaseVitalSignType> DiseaseVitalSignType { get; set; } = new List<DiseaseVitalSignType>();

    public virtual ICollection<MedicationVitalSignType> MedicationVitalSignType { get; set; } = new List<MedicationVitalSignType>();

    public virtual ICollection<VitalSignDetails> VitalSignDetails { get; set; } = new List<VitalSignDetails>();

    public virtual ICollection<VitalSignRelationships> VitalSignRelationships { get; set; } = new List<VitalSignRelationships>();

    public virtual VitalSignTypeThreshold? VitalSignTypeThreshold { get; set; }
}
