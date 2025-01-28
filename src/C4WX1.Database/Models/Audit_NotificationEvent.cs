using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_NotificationEvent
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int NotificationEventID { get; set; }

    public int NotificationId_FK { get; set; }

    public int EventID_FK { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
