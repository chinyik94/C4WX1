using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class UserCategoryRole
{
    public int UserCategoryID_FK { get; set; }

    public int RoleID_FK { get; set; }

    public string Role { get; set; } = null!;

    public virtual Role RoleID_FKNavigation { get; set; } = null!;

    public virtual UserCategory UserCategoryID_FKNavigation { get; set; } = null!;
}
