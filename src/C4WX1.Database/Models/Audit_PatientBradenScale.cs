﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_PatientBradenScale
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int PatientBradenScaleID { get; set; }

    public string Type { get; set; } = null!;

    public int? VitalSignDetailID_FK { get; set; }

    public int? Score1 { get; set; }

    public int? Score2 { get; set; }

    public int? Score3 { get; set; }

    public int? Score4 { get; set; }

    public int? Score5 { get; set; }

    public int? Score6 { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public bool IsDeleted { get; set; }
}
