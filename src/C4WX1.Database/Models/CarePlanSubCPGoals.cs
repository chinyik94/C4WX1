using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class CarePlanSubCPGoals
{
    public int CarePlanSubID_FK { get; set; }

    public int CPGoalsID_FK { get; set; }

    public virtual CPGoals CPGoalsID_FKNavigation { get; set; } = null!;

    public virtual CarePlanSub CarePlanSubID_FKNavigation { get; set; } = null!;
}
