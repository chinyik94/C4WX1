using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_InitialCareAssessmentVitalSign
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int InitialCareAssessmentID_FK { get; set; }

    public int VitalSignID_FK { get; set; }

    public DateTime? TimeOfRecord { get; set; }
}
