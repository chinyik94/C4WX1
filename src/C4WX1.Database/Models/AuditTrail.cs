﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class AuditTrail
{
    public int AuditTrailId { get; set; }

    public string AuditAction { get; set; } = null!;

    public string? Module { get; set; }

    public string Event { get; set; } = null!;

    public string? IPAddress { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public string? APIRequest { get; set; }

    public virtual Users? CreatedBy_FKNavigation { get; set; }
}
