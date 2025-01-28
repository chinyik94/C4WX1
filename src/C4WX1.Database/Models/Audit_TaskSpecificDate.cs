﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_TaskSpecificDate
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int TaskSpecificDateID { get; set; }

    public int TaskID_FK { get; set; }

    public DateTime TaskDate { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public bool IsDeleted { get; set; }
}
