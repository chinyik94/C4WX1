using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class vw_PushScores
{
    public int? PatientWoundVisitID { get; set; }

    public int? LengthXWidthScore { get; set; }

    public int? ExudateAmountScore { get; set; }

    public int? TissueTypeScore { get; set; }

    public int? TotalScore { get; set; }
}
