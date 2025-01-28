﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_PatientAMTAnswer
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int PatientAMTID_FK { get; set; }

    public int AMTQuestionID_FK { get; set; }

    public int? Answer { get; set; }
}
