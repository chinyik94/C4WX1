using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_NotificationVitalSignDetails
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int id { get; set; }

    public int notificationId { get; set; }

    public DateTime createdDate { get; set; }

    public DateTime? updatedDate { get; set; }

    public int VitalSignDetailId { get; set; }
}
