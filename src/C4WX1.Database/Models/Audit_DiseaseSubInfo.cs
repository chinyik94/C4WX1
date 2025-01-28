using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_DiseaseSubInfo
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int DiseaseSubInfoID { get; set; }

    public string DiseaseSubInfo { get; set; } = null!;

    public int DiseaseID_FK { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }
}
