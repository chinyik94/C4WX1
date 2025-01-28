﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_PatientRAF
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int PatientRAFID { get; set; }

    public string Type { get; set; } = null!;

    public int? VitalSignDetailID_FK { get; set; }

    public int? Score1 { get; set; }

    public int? Score2 { get; set; }

    public int? Score3 { get; set; }

    public int? Score4 { get; set; }

    public int? Score5a { get; set; }

    public int? Score5b { get; set; }

    public int? Score5c { get; set; }

    public int? Score5d { get; set; }

    public int? Score6 { get; set; }

    public int? Score7 { get; set; }

    public int? Score8 { get; set; }

    public int? Score9 { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public bool IsDeleted { get; set; }
}
