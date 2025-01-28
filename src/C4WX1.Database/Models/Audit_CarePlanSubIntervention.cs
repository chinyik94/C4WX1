using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_CarePlanSubIntervention
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int CarePlanSubID_FK { get; set; }

    public int InterventionID_FK { get; set; }
}
