﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_DiseaseInfo
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int DiseaseInfoID { get; set; }

    public string DiseaseInfo { get; set; } = null!;

    public int DiseaseID_FK { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }
}
