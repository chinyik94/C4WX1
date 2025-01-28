﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class PatientImmunisation
{
    public int ImmunisationID { get; set; }

    public int? PatientID_FK { get; set; }

    public string? Name { get; set; }

    public DateTime? Date { get; set; }

    public string? Place { get; set; }

    public DateTime? NextDate { get; set; }

    public string? Remarks { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public virtual Patient? PatientID_FKNavigation { get; set; }
}
