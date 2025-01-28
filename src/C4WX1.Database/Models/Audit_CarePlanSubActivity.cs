using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_CarePlanSubActivity
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int CarePlanSubID_FK { get; set; }

    public int ActivityID_FK { get; set; }
}
