﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_MobileAppVersioning
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int MobileVersionId { get; set; }

    public string? AppName { get; set; }

    public string? DeviceType { get; set; }

    public string? Version { get; set; }

    public string? Status { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }
}
