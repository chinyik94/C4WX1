﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Activity
{
    public int ActivityID { get; set; }

    public int ProblemListID_FK { get; set; }

    public string? ActivityDetail { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public int DiseaseID_FK { get; set; }

    public int? DiseaseSubInfoID_FK { get; set; }

    public virtual ICollection<CarePlanSubActivity> CarePlanSubActivity { get; set; } = new List<CarePlanSubActivity>();

    public virtual Disease DiseaseID_FKNavigation { get; set; } = null!;

    public virtual ProblemList ProblemListID_FKNavigation { get; set; } = null!;
}
