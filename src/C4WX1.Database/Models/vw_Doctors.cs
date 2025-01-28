using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class vw_Doctors
{
    public int? InternalId { get; set; }

    public int? ExternalId { get; set; }

    public string? DoctorName { get; set; }
}
