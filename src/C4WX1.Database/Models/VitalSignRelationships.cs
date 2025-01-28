using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class VitalSignRelationships
{
    public int id { get; set; }

    public int vitalSignTypeId { get; set; }

    public int patientId { get; set; }

    public int thresholdId { get; set; }

    public virtual Patient patient { get; set; } = null!;

    public virtual Thresholds threshold { get; set; } = null!;

    public virtual VitalSignTypes vitalSignType { get; set; } = null!;
}
