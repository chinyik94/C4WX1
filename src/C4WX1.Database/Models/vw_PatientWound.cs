using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class vw_PatientWound
{
    public int? PatientID { get; set; }

    public int? PatientWoundID { get; set; }

    public int? PatientWoundVisitID { get; set; }

    public string? LocationOfWound { get; set; }

    public string? Site { get; set; }

    public string? patientName { get; set; }

    public string? Status { get; set; }

    public string? createdBy { get; set; }

    public string? modifiedBy { get; set; }

    public int? CreatedBy_FK { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public DateOnly? LastVisitDate { get; set; }

    public DateTime? NextReviewDate { get; set; }

    public DateTime? NextTreatmentDate { get; set; }

    public string? Category { get; set; }

    public string? Stage { get; set; }
}
