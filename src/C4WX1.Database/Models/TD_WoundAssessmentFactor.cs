using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class TD_WoundAssessmentFactor
{
    public int TD_WoundAssessmentID_FK { get; set; }

    public int CodeID_FK { get; set; }

    public virtual Code CodeID_FKNavigation { get; set; } = null!;
}
