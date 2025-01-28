using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class vw_CarePlanSystemDisease
{
    public int? CarePlanID { get; set; }

    public int? SystemID_FK { get; set; }

    public int? DiseaseID_FK { get; set; }

    public bool? IsDeleted { get; set; }

    public bool? IsClosed { get; set; }
}
