using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_UserAddress
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int UserLocationID { get; set; }

    public int UserID_FK { get; set; }

    public string Address1 { get; set; } = null!;

    public string? Address2 { get; set; }

    public string? Address3 { get; set; }

    public string? PostalCode { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public bool IsDeleted { get; set; }
}
