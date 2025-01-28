﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class VitalSignDetails
{
    public int id { get; set; }

    public int vitalSignTypeId { get; set; }

    public int vitalSignId { get; set; }

    public decimal detailValue { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<NotificationVitalSignDetails> NotificationVitalSignDetails { get; set; } = new List<NotificationVitalSignDetails>();

    public virtual ICollection<PatientAMT> PatientAMT { get; set; } = new List<PatientAMT>();

    public virtual ICollection<PatientBradenScale> PatientBradenScale { get; set; } = new List<PatientBradenScale>();

    public virtual ICollection<PatientEBASDEP> PatientEBASDEP { get; set; } = new List<PatientEBASDEP>();

    public virtual ICollection<PatientGCS> PatientGCS { get; set; } = new List<PatientGCS>();

    public virtual ICollection<PatientMBI> PatientMBI { get; set; } = new List<PatientMBI>();

    public virtual ICollection<PatientMFS> PatientMFS { get; set; } = new List<PatientMFS>();

    public virtual ICollection<PatientMMSE> PatientMMSE { get; set; } = new List<PatientMMSE>();

    public virtual ICollection<PatientRAF> PatientRAF { get; set; } = new List<PatientRAF>();

    public virtual VitalSigns vitalSign { get; set; } = null!;

    public virtual VitalSignTypes vitalSignType { get; set; } = null!;
}
