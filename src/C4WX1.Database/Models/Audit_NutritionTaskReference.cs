using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_NutritionTaskReference
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int ReferenceID { get; set; }

    public int CodeId_FK { get; set; }

    public string? ReferenceImage { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public bool IsDeleted { get; set; }

    public int? Value { get; set; }
}
