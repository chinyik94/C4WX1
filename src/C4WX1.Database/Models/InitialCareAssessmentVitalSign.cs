using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class InitialCareAssessmentVitalSign
{
    public int InitialCareAssessmentID_FK { get; set; }

    public int VitalSignID_FK { get; set; }

    public DateTime? TimeOfRecord { get; set; }
}
