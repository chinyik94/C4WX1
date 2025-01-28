using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_GroupRole
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int GroupId_FK { get; set; }

    public int RoleId_FK { get; set; }

    public string Role { get; set; } = null!;
}
