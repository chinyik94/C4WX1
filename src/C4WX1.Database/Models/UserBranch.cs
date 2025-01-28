using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class UserBranch
{
    public int UserID_FK { get; set; }

    public int BranchID_FK { get; set; }

    public virtual Branch BranchID_FKNavigation { get; set; } = null!;

    public virtual Users UserID_FKNavigation { get; set; } = null!;
}
