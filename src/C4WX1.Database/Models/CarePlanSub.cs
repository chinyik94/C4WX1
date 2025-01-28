﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class CarePlanSub
{
    public int CarePlanSubID { get; set; }

    public int CarePlanID_FK { get; set; }

    public int SubCarePlanName { get; set; }

    public string? Goal { get; set; }

    public DateTime? ReviewDate { get; set; }

    public int? PersonInCharge { get; set; }

    public DateTime? ApprovedDate { get; set; }

    public bool? IsDeleted { get; set; }

    public int? GroupCode { get; set; }

    public string? CarePlanGroupName { get; set; }

    public int? DiseaseID_FK { get; set; }

    public string? InterventionStatus { get; set; }

    public string? GoalStatus { get; set; }

    public virtual ICollection<CarePlanDetail> CarePlanDetail { get; set; } = new List<CarePlanDetail>();

    public virtual CarePlan CarePlanID_FKNavigation { get; set; } = null!;

    public virtual ICollection<CarePlanSubActivity> CarePlanSubActivity { get; set; } = new List<CarePlanSubActivity>();

    public virtual ICollection<CarePlanSubCPGoals> CarePlanSubCPGoals { get; set; } = new List<CarePlanSubCPGoals>();

    public virtual ICollection<CarePlanSubGoal> CarePlanSubGoal { get; set; } = new List<CarePlanSubGoal>();

    public virtual ICollection<CarePlanSubIntervention> CarePlanSubIntervention { get; set; } = new List<CarePlanSubIntervention>();

    public virtual ICollection<CarePlanSubProblemList> CarePlanSubProblemList { get; set; } = new List<CarePlanSubProblemList>();
}
