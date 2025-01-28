﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class CarePlan
{
    public int CarePlanID { get; set; }

    public int? PatientID_FK { get; set; }

    public int? DiagnosisID_FK { get; set; }

    public int? CarePlanStatusID_FK { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public bool? IsDeleted { get; set; }

    public int? InitialCareAssessmentID_FK { get; set; }

    public int? CarePlanDetailID_FK { get; set; }

    public string? CarePlanName { get; set; }

    public bool? IsClosed { get; set; }

    public int? PersonInCharge { get; set; }

    public string? CarePlanType { get; set; }

    public string? Remark { get; set; }

    public virtual CarePlanStatus? CarePlanStatusID_FKNavigation { get; set; }

    public virtual ICollection<CarePlanSub> CarePlanSub { get; set; } = new List<CarePlanSub>();

    public virtual ICollection<CareReport> CareReport { get; set; } = new List<CareReport>();

    public virtual Diagnosis? DiagnosisID_FKNavigation { get; set; }

    public virtual Patient? PatientID_FKNavigation { get; set; }
}
