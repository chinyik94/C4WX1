using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_ProblemListGoal
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int ProblemListGoalID { get; set; }

    public int ProblemListID_FK { get; set; }

    public string? Goal { get; set; }

    public int? Action { get; set; }

    public int? ScoreTypeID { get; set; }

    public int? OperatorID { get; set; }
}
