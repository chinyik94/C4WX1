using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class NotificationMessageTemplates
{
    public int id { get; set; }

    public string notificationgroupCode { get; set; } = null!;

    public string? notificationSubject { get; set; }

    public string notificationMessage { get; set; } = null!;

    public DateTime createdDate { get; set; }

    public DateTime? updatedDate { get; set; }

    public virtual Types notificationgroupCodeNavigation { get; set; } = null!;
}
