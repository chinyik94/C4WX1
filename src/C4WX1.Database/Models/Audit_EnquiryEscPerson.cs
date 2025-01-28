using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_EnquiryEscPerson
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int EnquiryConfigID { get; set; }

    public int UserID_FK { get; set; }
}
