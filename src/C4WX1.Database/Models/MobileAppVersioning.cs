﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class MobileAppVersioning
{
    public int MobileVersionId { get; set; }

    public string? AppName { get; set; }

    public string? DeviceType { get; set; }

    public string? Version { get; set; }

    public string? Status { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public virtual Users? CreatedBy_FKNavigation { get; set; }

    public virtual Users? ModifiedBy_FKNavigation { get; set; }
}
