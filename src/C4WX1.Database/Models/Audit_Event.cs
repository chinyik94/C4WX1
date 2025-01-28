﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_Event
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int EventID { get; set; }

    public string EventName { get; set; } = null!;

    public int EventTypeID_FK { get; set; }

    public int PeriodTypeID_FK { get; set; }

    public DateTime FromDate { get; set; }

    public DateTime ToDate { get; set; }

    public string? Remarks { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public bool IsDeleted { get; set; }

    public int? UserCategory_FK { get; set; }
}
