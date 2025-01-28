using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_PatientMedicationConsumeAttachment
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int PatientMedicationConsumeAttachmentID { get; set; }

    public int PatientMedicationConsumeID_FK { get; set; }

    public string? Filename { get; set; }

    public string? Physical { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public bool IsDeleted { get; set; }

    public bool? IsEndDate { get; set; }
}
