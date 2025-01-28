using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class PatientReferralService
{
    public int PatientReferralID_FK { get; set; }

    public int ServiceID_FK { get; set; }

    public virtual PatientReferral PatientReferralID_FKNavigation { get; set; } = null!;

    public virtual Code ServiceID_FKNavigation { get; set; } = null!;
}
