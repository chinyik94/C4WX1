using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_CarePlanSubGoal
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int CarePlanSubGoalID { get; set; }

    public int CarePlanSubID_FK { get; set; }

    public int? ScoreTypeID { get; set; }

    public int? OperatorID { get; set; }

    public decimal? Score1 { get; set; }

    public decimal? Score2 { get; set; }

    public string? CarePlanSubGoalName { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public int? DiseaseID_FK { get; set; }
}
