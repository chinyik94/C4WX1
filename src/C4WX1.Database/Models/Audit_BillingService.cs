﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_BillingService
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int ServiceID { get; set; }

    public string Title { get; set; } = null!;

    public int CategoryID_FK { get; set; }

    public decimal CostPerSession { get; set; }

    public bool Weekend { get; set; }

    public string Status { get; set; } = null!;

    public string Remarks { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public int CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public bool IsDeleted { get; set; }
}
