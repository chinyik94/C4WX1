﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class PatientFamilyHistory
{
    public int PatientFamilyHistoryID { get; set; }

    public int? PatientID_FK { get; set; }

    public int? InitialCareAssessmentID_FK { get; set; }

    public int DiseaseID_FK { get; set; }

    public int? DiseaseSubInfoID_FK { get; set; }

    public int? YearDiagnose { get; set; }

    public string? Remarks { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public bool IsDeleted { get; set; }

    public string? Relationship { get; set; }

    public virtual Disease DiseaseID_FKNavigation { get; set; } = null!;

    public virtual DiseaseSubInfo? DiseaseSubInfoID_FKNavigation { get; set; }

    public virtual InitialCareAssessment? InitialCareAssessmentID_FKNavigation { get; set; }

    public virtual Patient? PatientID_FKNavigation { get; set; }
}
