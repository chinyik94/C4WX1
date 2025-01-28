using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_CarePlanSubProblemList
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int CarePlanSubProblemListID { get; set; }

    public int CarePlanSubID_FK { get; set; }

    public int ProblemListID_FK { get; set; }

    public DateTime? PLReviewDate { get; set; }

    public string? PLStatus { get; set; }

    public int? PersonInChargeID_FK { get; set; }

    public int? TypeOfGoal { get; set; }

    public string? Goal { get; set; }
}
