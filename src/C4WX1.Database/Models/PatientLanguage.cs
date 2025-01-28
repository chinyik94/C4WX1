﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class PatientLanguage
{
    public int PatientID_FK { get; set; }

    public int CodeID_FK { get; set; }

    public virtual Code CodeID_FKNavigation { get; set; } = null!;

    public virtual Patient PatientID_FKNavigation { get; set; } = null!;
}
