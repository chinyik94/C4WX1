﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_PatientWoundReviewBy
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int PatientWoundReviewById { get; set; }

    public int? PatientWoundVisitID_FK { get; set; }

    public int? UserId_FK { get; set; }

    public string? ReviewComments { get; set; }

    public DateTime? ReviewDate { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }
}
