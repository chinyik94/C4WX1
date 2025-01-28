using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_UserCategoryRole
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int UserCategoryID_FK { get; set; }

    public int RoleID_FK { get; set; }

    public string Role { get; set; } = null!;
}
