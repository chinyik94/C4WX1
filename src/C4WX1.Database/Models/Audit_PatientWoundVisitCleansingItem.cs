﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_PatientWoundVisitCleansingItem
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int PatientWoundVisitID_FK { get; set; }

    public int CodeID_FK { get; set; }
}
