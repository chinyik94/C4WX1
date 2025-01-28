using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class CareReportSystemInfo
{
    public int CareReportSystemInfoID { get; set; }

    public bool? IsUpdatePrimaryDoctor { get; set; }

    public int? PrimaryDoctorUserID_FK { get; set; }

    public string? PrimaryDoctorName { get; set; }

    public bool? IsUpdateSecondaryDoctor { get; set; }

    public int? SecondaryDoctorUserID_FK { get; set; }

    public string? SecondaryDoctorName { get; set; }

    public bool? IsUpdateKeyPerson1 { get; set; }

    public int? KeyPerson1UserID_FK { get; set; }

    public bool? IsUpdateKeyPerson2 { get; set; }

    public int? KeyPerson2UserID_FK { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public bool IsUpdateFamily { get; set; }

    public virtual ICollection<CareReport> CareReport { get; set; } = new List<CareReport>();

    public virtual Users? KeyPerson1UserID_FKNavigation { get; set; }

    public virtual Users? KeyPerson2UserID_FKNavigation { get; set; }

    public virtual PatientClinician? PrimaryDoctorUserID_FKNavigation { get; set; }

    public virtual PatientClinician? SecondaryDoctorUserID_FKNavigation { get; set; }
}
