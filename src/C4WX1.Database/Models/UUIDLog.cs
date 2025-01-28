﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class UUIDLog
{
    public int UUIDLogID { get; set; }

    public string? UUID { get; set; }

    public bool? IsUpdated { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public int? PatientWoundVisitID { get; set; }
}
