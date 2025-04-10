﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class PatientReferral
{
    public int PatientReferralID { get; set; }

    public int? PrimaryClinicianID_FK { get; set; }

    public int? SecondaryClinicianID_FK { get; set; }

    public bool? PatientAwareDiagnose { get; set; }

    public bool? FamilyAwareDiagnose { get; set; }

    public bool? PatientAwarePrognosis { get; set; }

    public bool? FamilyAwarePrognosis { get; set; }

    public string? PatientAwareDiagnoseReason { get; set; }

    public string? FamilyAwareDiagnoseReason { get; set; }

    public string? PatientAwarePrognosisReason { get; set; }

    public string? FamilyAwarePrognosisReason { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public int? PrimaryNurseID_FK { get; set; }

    public int? SecondaryNurseID_FK { get; set; }

    public virtual ICollection<InitialCareAssessment> InitialCareAssessment { get; set; } = new List<InitialCareAssessment>();

    public virtual ICollection<Patient> Patient { get; set; } = new List<Patient>();

    public virtual ICollection<PatientReferralService> PatientReferralService { get; set; } = new List<PatientReferralService>();

    public virtual PatientClinician? PrimaryClinicianID_FKNavigation { get; set; }

    public virtual PatientClinician? PrimaryNurseID_FKNavigation { get; set; }

    public virtual PatientClinician? SecondaryClinicianID_FKNavigation { get; set; }

    public virtual PatientClinician? SecondaryNurseID_FKNavigation { get; set; }
}