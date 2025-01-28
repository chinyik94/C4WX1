using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class TeleconsultationRecording
{
    public int RecordingID { get; set; }

    public int RecordingType_FK { get; set; }

    public int PatientID_FK { get; set; }

    public string Sid { get; set; } = null!;

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public virtual Patient PatientID_FKNavigation { get; set; } = null!;

    public virtual Code RecordingType_FKNavigation { get; set; } = null!;
}
