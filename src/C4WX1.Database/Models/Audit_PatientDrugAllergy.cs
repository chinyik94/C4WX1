﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_PatientDrugAllergy
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int DrugAllergyID { get; set; }

    public int? PatientID_FK { get; set; }

    public int? InitialCareAssessmentID_FK { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public bool IsDeleted { get; set; }

    public int? ReactionID_FK { get; set; }

    public int? MedicationID_FK { get; set; }

    public int? ReferID_FK { get; set; }
}
