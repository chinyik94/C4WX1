﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class LoginDevice
{
    public int LoginDeviceId { get; set; }

    public int UserId_FK { get; set; }

    public string DeviceType { get; set; } = null!;

    public string DeviceID { get; set; } = null!;

    public DateTime CreatedDate { get; set; }
}