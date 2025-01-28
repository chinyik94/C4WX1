﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_APIOrderTask
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int APIOrderTaskID { get; set; }

    public int APIOrderID_FK { get; set; }

    public int? TaskID { get; set; }

    public string? TaskName { get; set; }

    public int? TaskTypeID { get; set; }

    public DateTime? TaskStartDateTime { get; set; }

    public DateTime? TaskEndDateTime { get; set; }

    public int? TaskFrequencyID { get; set; }

    public int? TaskFrequency { get; set; }

    public int? TaskPeriod { get; set; }

    public string? TaskPeriodUnit { get; set; }

    public string? TaskDisplay { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public bool IsDeleted { get; set; }

    public string? Remark { get; set; }
}
