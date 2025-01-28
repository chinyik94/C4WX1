﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class PatientFacility
{
    public int PatientID_FK { get; set; }

    public int FacilityID_FK { get; set; }

    public virtual Facility FacilityID_FKNavigation { get; set; } = null!;

    public virtual Patient PatientID_FKNavigation { get; set; } = null!;
}
