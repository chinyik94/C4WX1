using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_Disease
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int DiseaseID { get; set; }

    public string DiseaseName { get; set; } = null!;

    public int SystemID_FK { get; set; }

    public bool IsAdditionalInfo { get; set; }

    public bool IsSuggestPalliativeCare { get; set; }

    public bool IsSystemUsed { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public string? AdditionalInfo { get; set; }

    public string? DiseaseCode { get; set; }
}
