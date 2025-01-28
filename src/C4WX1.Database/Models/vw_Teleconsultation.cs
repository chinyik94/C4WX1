using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class vw_Teleconsultation
{
    public int? TaskID { get; set; }

    public int? UserID { get; set; }

    public int? PatientID { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }
}
