using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_LoginDevice
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int LoginDeviceId { get; set; }

    public int UserId_FK { get; set; }

    public string DeviceType { get; set; } = null!;

    public string DeviceID { get; set; } = null!;

    public DateTime CreatedDate { get; set; }
}
