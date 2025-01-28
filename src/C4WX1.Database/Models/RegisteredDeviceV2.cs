﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class RegisteredDeviceV2
{
    public int RegisteredDeviceID { get; set; }

    public int? UserId_FK { get; set; }

    public string? DeviceId { get; set; }

    public string? DeviceName { get; set; }

    public string? DeviceType { get; set; }

    public string? DeviceToken { get; set; }

    public string? FirstRegisterIpAddress { get; set; }

    public string? Status { get; set; }

    public string? Remarks { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public string? AppName { get; set; }

    public string? Version { get; set; }
}
