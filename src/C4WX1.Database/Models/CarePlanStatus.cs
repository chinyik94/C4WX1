﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class CarePlanStatus
{
    public int CarePlanStatusID { get; set; }

    public string? CarePlanStatus1 { get; set; }

    public string? CareReviewFrequency { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public virtual ICollection<CarePlan> CarePlan { get; set; } = new List<CarePlan>();
}
