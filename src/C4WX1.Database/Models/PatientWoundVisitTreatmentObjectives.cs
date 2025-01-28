using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class PatientWoundVisitTreatmentObjectives
{
    public int PatientWoundVisitID_FK { get; set; }

    public int ObjectiveID_FK { get; set; }

    public virtual Code ObjectiveID_FKNavigation { get; set; } = null!;

    public virtual PatientWoundVisit PatientWoundVisitID_FKNavigation { get; set; } = null!;
}
