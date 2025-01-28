﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Event
{
    public int EventID { get; set; }

    public string EventName { get; set; } = null!;

    public int EventTypeID_FK { get; set; }

    public int PeriodTypeID_FK { get; set; }

    public DateTime FromDate { get; set; }

    public DateTime ToDate { get; set; }

    public string? Remarks { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public bool IsDeleted { get; set; }

    public int? UserCategory_FK { get; set; }

    public virtual Users? CreatedBy_FKNavigation { get; set; }

    public virtual Code EventTypeID_FKNavigation { get; set; } = null!;

    public virtual ICollection<EventUser> EventUser { get; set; } = new List<EventUser>();

    public virtual ICollection<EventUserLog> EventUserLog { get; set; } = new List<EventUserLog>();

    public virtual ICollection<NotificationEvent> NotificationEvent { get; set; } = new List<NotificationEvent>();

    public virtual Code PeriodTypeID_FKNavigation { get; set; } = null!;

    public virtual UserCategory? UserCategory_FKNavigation { get; set; }
}
