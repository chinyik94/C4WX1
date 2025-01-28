using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_VitalSignDetails
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int id { get; set; }

    public int vitalSignTypeId { get; set; }

    public int vitalSignId { get; set; }

    public decimal detailValue { get; set; }

    public bool IsDeleted { get; set; }
}
