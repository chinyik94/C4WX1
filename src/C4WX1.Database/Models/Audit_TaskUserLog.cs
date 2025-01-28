﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_TaskUserLog
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int TaskUserLogID { get; set; }

    public int TaskID_FK { get; set; }

    public int UserID_FK { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string? Status { get; set; }

    public string? FailReason { get; set; }

    public DateTime? StatusDate { get; set; }

    public bool? HideDashboard { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public bool IsDeleted { get; set; }
}
