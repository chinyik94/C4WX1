using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_CarePlanSubCPGoals
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int CarePlanSubID_FK { get; set; }

    public int CPGoalsID_FK { get; set; }
}
