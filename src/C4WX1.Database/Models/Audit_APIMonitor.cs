using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_APIMonitor
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int? MonitorID { get; set; }

    public string UUID { get; set; } = null!;

    public string APIName { get; set; } = null!;

    public DateTime CreatedDate { get; set; }
}
