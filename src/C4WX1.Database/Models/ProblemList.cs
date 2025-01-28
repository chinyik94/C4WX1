﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class ProblemList
{
    public int ProblemListID { get; set; }

    public int DiseaseID_FK { get; set; }

    public string ProblemInfo { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public int? TypeOfGoal { get; set; }

    public int? DiseaseSubInfoID_FK { get; set; }

    public virtual ICollection<Activity> Activity { get; set; } = new List<Activity>();

    public virtual ICollection<CarePlanSubProblemList> CarePlanSubProblemList { get; set; } = new List<CarePlanSubProblemList>();

    public virtual Disease DiseaseID_FKNavigation { get; set; } = null!;

    public virtual ICollection<ProblemListGoal> ProblemListGoal { get; set; } = new List<ProblemListGoal>();
}
