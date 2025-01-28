﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class ExternalDoctor
{
    public int ExternalDoctorID { get; set; }

    public string Name { get; set; } = null!;

    public int? ClinicianTypeID_FK { get; set; }

    public string? Contact { get; set; }

    public string? Email { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public bool IsDeleted { get; set; }

    public int? AccessHospitalID_FK { get; set; }

    public virtual UserType? ClinicianTypeID_FKNavigation { get; set; }

    public virtual ICollection<PatientClinician> PatientClinician { get; set; } = new List<PatientClinician>();

    public virtual ICollection<PatientWoundVisitClinician> PatientWoundVisitClinician { get; set; } = new List<PatientWoundVisitClinician>();
}
