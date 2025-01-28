﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class EventUserLog
{
    public int EventUserLogID { get; set; }

    public int EventID_FK { get; set; }

    public int UserID_FK { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Event EventID_FKNavigation { get; set; } = null!;

    public virtual Users UserID_FKNavigation { get; set; } = null!;
}
