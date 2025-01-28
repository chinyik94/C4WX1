using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class PatientMedicationSupply
{
    public int PatientMedicationID_FK { get; set; }

    public int SupplyID_FK { get; set; }

    public virtual PatientMedication PatientMedicationID_FKNavigation { get; set; } = null!;

    public virtual Code SupplyID_FKNavigation { get; set; } = null!;
}
