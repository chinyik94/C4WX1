﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class APIMonitor
{
    public int MonitorID { get; set; }

    public string UUID { get; set; } = null!;

    public string APIName { get; set; } = null!;

    public DateTime CreatedDate { get; set; }
}
