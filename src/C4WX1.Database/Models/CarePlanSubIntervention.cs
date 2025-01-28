﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class CarePlanSubIntervention
{
    public int CarePlanSubID_FK { get; set; }

    public int InterventionID_FK { get; set; }

    public virtual CarePlanSub CarePlanSubID_FKNavigation { get; set; } = null!;

    public virtual Intervention InterventionID_FKNavigation { get; set; } = null!;
}
