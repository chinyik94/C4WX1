using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_NotificationTask
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int? NotificationTaskID { get; set; }

    public int NotificationId_FK { get; set; }

    public int TaskID_FK { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
