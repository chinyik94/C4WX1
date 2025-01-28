﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_TreatmentTOL
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int TreatmentTOLID { get; set; }

    public int TListItemID_FK { get; set; }
}
