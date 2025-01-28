using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class UserRole
{
    public int UserId_FK { get; set; }

    public int RoleId_FK { get; set; }

    public string Role { get; set; } = null!;

    public virtual Role RoleId_FKNavigation { get; set; } = null!;

    public virtual Users UserId_FKNavigation { get; set; } = null!;
}
