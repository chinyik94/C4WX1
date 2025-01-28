using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_PatientMedicationSupply
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int PatientMedicationID_FK { get; set; }

    public int SupplyID_FK { get; set; }
}
