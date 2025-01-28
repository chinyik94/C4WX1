﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class APNSNotification
{
    public int Id { get; set; }

    public string? NotificationMessage { get; set; }

    public string? NotificationTitle { get; set; }

    public int? UserID { get; set; }

    public bool? SentStatus { get; set; }

    public bool? IsCritical { get; set; }

    public int? TaskID { get; set; }
}
