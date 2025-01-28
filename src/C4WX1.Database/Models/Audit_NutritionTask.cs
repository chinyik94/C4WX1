using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_NutritionTask
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int NutritionTaskID { get; set; }

    public int ActionTypeID_FK { get; set; }

    public int? PatientID_FK { get; set; }

    public string? Food { get; set; }

    public string? Liquid { get; set; }

    public string? Method { get; set; }

    public string? BeforeImage { get; set; }

    public string? AfterImage { get; set; }

    public string? Remarks { get; set; }

    public int? TypeReferenceID_FK { get; set; }

    public int? AmountReferenceID_FK { get; set; }

    public int? ColorReferenceID_FK { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public bool IsDeleted { get; set; }

    public int? GivenAmount { get; set; }

    public int? TakenAmount { get; set; }

    public string? Unit { get; set; }
}
