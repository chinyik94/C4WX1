﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_CarePlanSubProblemListGoal
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int CarePlanSubProblemListGoalID { get; set; }

    public int CarePlanSubProblemListID_FK { get; set; }

    public string? Goal { get; set; }

    public int? Action { get; set; }

    public int? ScoreTypeID { get; set; }

    public int? OperatorID { get; set; }

    public decimal? Score1 { get; set; }

    public decimal? Score2 { get; set; }

    public int? ProblemListGoalID_FK { get; set; }
}
