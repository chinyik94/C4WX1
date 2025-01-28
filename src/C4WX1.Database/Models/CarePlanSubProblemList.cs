﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class CarePlanSubProblemList
{
    public int CarePlanSubProblemListID { get; set; }

    public int CarePlanSubID_FK { get; set; }

    public int ProblemListID_FK { get; set; }

    public DateTime? PLReviewDate { get; set; }

    public string? PLStatus { get; set; }

    public int? PersonInChargeID_FK { get; set; }

    public int? TypeOfGoal { get; set; }

    public string? Goal { get; set; }

    public virtual CarePlanSub CarePlanSubID_FKNavigation { get; set; } = null!;

    public virtual ICollection<CarePlanSubProblemListGoal> CarePlanSubProblemListGoal { get; set; } = new List<CarePlanSubProblemListGoal>();

    public virtual ProblemList ProblemListID_FKNavigation { get; set; } = null!;
}
