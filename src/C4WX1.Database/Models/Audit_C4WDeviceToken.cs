using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_C4WDeviceToken
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int C4WDeviceTokenId { get; set; }

    public string? OldDeviceToken { get; set; }

    public string? NewDeviceToken { get; set; }

    public string? ClientEnvironment { get; set; }

    public string? Device { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }
}
