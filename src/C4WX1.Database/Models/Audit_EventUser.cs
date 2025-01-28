﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_EventUser
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int EventUserID { get; set; }

    public int EventID_FK { get; set; }

    public int UserID_FK { get; set; }

    public string UserType { get; set; } = null!;

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public bool IsDeleted { get; set; }
}
