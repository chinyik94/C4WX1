﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_APIOrderDiagnosis
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int APIOrderDiagnosisID { get; set; }

    public int APIOrderID_FK { get; set; }

    public string? DiagnosisType { get; set; }

    public string? DiagnosisDesc { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public bool IsDeleted { get; set; }
}
