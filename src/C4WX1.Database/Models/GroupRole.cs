﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class GroupRole
{
    public int GroupId_FK { get; set; }

    public int RoleId_FK { get; set; }

    public string Role { get; set; } = null!;

    public virtual Group GroupId_FKNavigation { get; set; } = null!;

    public virtual Role RoleId_FKNavigation { get; set; } = null!;
}
