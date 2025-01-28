﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class PatientWoundVisitAppearance
{
    public int PatientWoundVisitID_FK { get; set; }

    public int CodeID_FK { get; set; }

    public virtual Code CodeID_FKNavigation { get; set; } = null!;

    public virtual PatientWoundVisit PatientWoundVisitID_FKNavigation { get; set; } = null!;
}
