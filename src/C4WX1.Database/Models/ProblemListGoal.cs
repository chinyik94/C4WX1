using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class ProblemListGoal
{
    public int ProblemListGoalID { get; set; }

    public int ProblemListID_FK { get; set; }

    public string? Goal { get; set; }

    public int? Action { get; set; }

    public int? ScoreTypeID { get; set; }

    public int? OperatorID { get; set; }

    public virtual ICollection<CarePlanSubProblemListGoal> CarePlanSubProblemListGoal { get; set; } = new List<CarePlanSubProblemListGoal>();

    public virtual Code? Operator { get; set; }

    public virtual ProblemList ProblemListID_FKNavigation { get; set; } = null!;

    public virtual Code? ScoreType { get; set; }
}
