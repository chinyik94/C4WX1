using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class NotificationChat
{
    public int NotificationChatID { get; set; }

    public int NotificationId_FK { get; set; }

    public int ChatID_FK { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual Chat ChatID_FKNavigation { get; set; } = null!;

    public virtual Notifications NotificationId_FKNavigation { get; set; } = null!;
}
