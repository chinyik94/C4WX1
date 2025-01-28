﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class NotificationTask
{
    public int NotificationTaskID { get; set; }

    public int NotificationId_FK { get; set; }

    public int TaskID_FK { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual Notifications NotificationId_FKNavigation { get; set; } = null!;

    public virtual Task TaskID_FKNavigation { get; set; } = null!;
}
