using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_Chat
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int ChatID { get; set; }

    public string? Comment { get; set; }

    public string? Attachment { get; set; }

    public string? Attachment_Physical { get; set; }

    public int? ParentID_FK { get; set; }

    public int? PatientID_FK { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedBy_FK { get; set; }

    public bool IsDeleted { get; set; }

    public bool? Family { get; set; }
}
