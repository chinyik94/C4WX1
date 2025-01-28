﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Notifications
{
    public int id { get; set; }

    public int userId { get; set; }

    public string notificationTypeCode { get; set; } = null!;

    public bool isRead { get; set; }

    public bool isDeleted { get; set; }

    public DateTime createdDate { get; set; }

    public DateTime? updatedDate { get; set; }

    public int? FacilityID_FK { get; set; }

    public virtual Facility? FacilityID_FKNavigation { get; set; }

    public virtual ICollection<NotificationChat> NotificationChat { get; set; } = new List<NotificationChat>();

    public virtual ICollection<NotificationEvent> NotificationEvent { get; set; } = new List<NotificationEvent>();

    public virtual ICollection<NotificationTask> NotificationTask { get; set; } = new List<NotificationTask>();

    public virtual ICollection<NotificationVitalSignDetails> NotificationVitalSignDetails { get; set; } = new List<NotificationVitalSignDetails>();

    public virtual Types notificationTypeCodeNavigation { get; set; } = null!;

    public virtual Users user { get; set; } = null!;
}
