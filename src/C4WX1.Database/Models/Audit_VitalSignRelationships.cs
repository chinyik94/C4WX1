﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_VitalSignRelationships
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int id { get; set; }

    public int vitalSignTypeId { get; set; }

    public int patientId { get; set; }

    public int thresholdId { get; set; }
}
