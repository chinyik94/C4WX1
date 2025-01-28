﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class RecentView
{
    public int UserID_FK { get; set; }

    public int PatientID_FK { get; set; }

    public DateTime DateView { get; set; }

    public virtual Patient PatientID_FKNavigation { get; set; } = null!;

    public virtual Users UserID_FKNavigation { get; set; } = null!;
}
