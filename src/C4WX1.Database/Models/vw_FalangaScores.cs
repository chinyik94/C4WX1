using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class vw_FalangaScores
{
    public int? PatientWoundVisitID { get; set; }

    public string? HealingEdges { get; set; }

    public int? HealingEdges_Score { get; set; }

    public string? BlackEschar { get; set; }

    public int? BlackEschar_Score { get; set; }

    public string? GreatestWoundDepth { get; set; }

    public int? GreatestWoundDepth_Score { get; set; }

    public string? ExudateAmount { get; set; }

    public int? ExudateAmount_Score { get; set; }

    public bool? Edema { get; set; }

    public int? Edema_Score { get; set; }

    public string? PeriwoundDermatitis { get; set; }

    public int? PeriwoundDermatitis_Score { get; set; }

    public string? PeriwoundCallousFibrosis { get; set; }

    public int? PeriwoundCallousFibrosis_Score { get; set; }

    public string? PinkWoundBed { get; set; }

    public int? PinkWoundBed_Score { get; set; }

    public int? TotalScore { get; set; }
}
