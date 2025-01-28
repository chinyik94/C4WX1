using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_TeleconsultationRecording
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int RecordingID { get; set; }

    public int RecordingType { get; set; }

    public int PatientID_FK { get; set; }

    public string Sid { get; set; } = null!;

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }
}
