﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_RegisteredDevice
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int DeviceID { get; set; }

    public int? DeviceType { get; set; }

    public string? DeviceToken { get; set; }

    public int? UserID { get; set; }

    public bool? Status { get; set; }
}
