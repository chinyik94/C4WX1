using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_Notifications
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int id { get; set; }

    public int userId { get; set; }

    public string notificationTypeCode { get; set; } = null!;

    public bool isRead { get; set; }

    public bool isDeleted { get; set; }

    public DateTime createdDate { get; set; }

    public DateTime? updatedDate { get; set; }

    public int? FacilityID_FK { get; set; }
}
