using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_SystemForDisease
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int SystemID { get; set; }

    public string? System { get; set; }

    public bool IsSystemUsed { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public int? GroupCode { get; set; }
}
