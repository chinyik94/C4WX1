﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_UserCategory
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int UserCategoryID { get; set; }

    public string UserCategory { get; set; } = null!;

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public bool IsDeleted { get; set; }

    public int? UserCategoryOrganizationID_FK { get; set; }

    public bool? EnableGeoFencing { get; set; }
}
