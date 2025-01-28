﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class CarePlanSubActivity
{
    public int CarePlanSubID_FK { get; set; }

    public int ActivityID_FK { get; set; }

    public virtual Activity ActivityID_FKNavigation { get; set; } = null!;

    public virtual CarePlanSub CarePlanSubID_FKNavigation { get; set; } = null!;
}
