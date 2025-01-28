﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_PatientAccessLine
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int PatientAccessLineID { get; set; }

    public string AccessLine { get; set; } = null!;

    public int CareReportID_FK { get; set; }

    public DateTime DateOfInsertion { get; set; }

    public string Patent { get; set; } = null!;

    public string? PatentReSited { get; set; }

    public DateTime? PatentReSitedDate { get; set; }

    public string? PatentSite { get; set; }

    public DateTime DateDueForChange { get; set; }

    public string? AccessLineRemarks { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }
}
