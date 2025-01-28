﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_PatientEBASDEPAnswer
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int PatientEBASDEPID_FK { get; set; }

    public int EBASDEPQuestionID_FK { get; set; }

    public int? Answer { get; set; }
}
