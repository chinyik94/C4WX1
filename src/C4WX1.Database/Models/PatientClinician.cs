﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class PatientClinician
{
    public int PatientClinicianID { get; set; }

    public int? PatientID_FK { get; set; }

    public int? InitialCareAssessmentID_FK { get; set; }

    public int? UserID_FK { get; set; }

    public int? ExternalDoctorID_FK { get; set; }

    public int? DiseaseID_FK { get; set; }

    public int? DiseaseSubInfoID_FK { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<CareReportSystemInfo> CareReportSystemInfoPrimaryDoctorUserID_FKNavigation { get; set; } = new List<CareReportSystemInfo>();

    public virtual ICollection<CareReportSystemInfo> CareReportSystemInfoSecondaryDoctorUserID_FKNavigation { get; set; } = new List<CareReportSystemInfo>();

    public virtual Disease? DiseaseID_FKNavigation { get; set; }

    public virtual DiseaseSubInfo? DiseaseSubInfoID_FKNavigation { get; set; }

    public virtual ExternalDoctor? ExternalDoctorID_FKNavigation { get; set; }

    public virtual InitialCareAssessment? InitialCareAssessmentID_FKNavigation { get; set; }

    public virtual Patient? PatientID_FKNavigation { get; set; }

    public virtual ICollection<PatientMedicalHistory> PatientMedicalHistory { get; set; } = new List<PatientMedicalHistory>();

    public virtual ICollection<PatientReferral> PatientReferralPrimaryClinicianID_FKNavigation { get; set; } = new List<PatientReferral>();

    public virtual ICollection<PatientReferral> PatientReferralPrimaryNurseID_FKNavigation { get; set; } = new List<PatientReferral>();

    public virtual ICollection<PatientReferral> PatientReferralSecondaryClinicianID_FKNavigation { get; set; } = new List<PatientReferral>();

    public virtual ICollection<PatientReferral> PatientReferralSecondaryNurseID_FKNavigation { get; set; } = new List<PatientReferral>();

    public virtual Users? UserID_FKNavigation { get; set; }
}
