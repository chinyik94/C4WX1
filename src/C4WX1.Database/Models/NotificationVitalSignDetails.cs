using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class NotificationVitalSignDetails
{
    public int id { get; set; }

    public int notificationId { get; set; }

    public DateTime createdDate { get; set; }

    public DateTime? updatedDate { get; set; }

    public int VitalSignDetailId { get; set; }

    public virtual VitalSignDetails VitalSignDetail { get; set; } = null!;

    public virtual Notifications notification { get; set; } = null!;
}
