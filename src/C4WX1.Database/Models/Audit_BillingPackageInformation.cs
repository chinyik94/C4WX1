﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_BillingPackageInformation
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int BillingPackageID { get; set; }

    public int BillingServiceID { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public bool IsDeleted { get; set; }

    public int Session { get; set; }
}
