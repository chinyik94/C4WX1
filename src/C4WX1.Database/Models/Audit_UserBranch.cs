using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_UserBranch
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int UserID_FK { get; set; }

    public int BranchID_FK { get; set; }
}
