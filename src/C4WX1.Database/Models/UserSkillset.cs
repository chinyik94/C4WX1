﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class UserSkillset
{
    public int UserID_FK { get; set; }

    public int CodeID_FK { get; set; }

    public virtual Code CodeID_FKNavigation { get; set; } = null!;

    public virtual Users UserID_FKNavigation { get; set; } = null!;
}
