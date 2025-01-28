using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_APIOrder
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int APIOrderId { get; set; }

    public string? OrderID { get; set; }

    public string? ResourceType { get; set; }

    public int? PatientID { get; set; }

    public string? PatientNRIC { get; set; }

    public string? PatientFirstName { get; set; }

    public string? PatientLastName { get; set; }

    public int? OrderedByID { get; set; }

    public string? OrderedByName { get; set; }

    public string? OrderedByInstitution { get; set; }

    public int? OrderedByInstitutionID { get; set; }

    public string? DoctorMCR { get; set; }

    public int? AcceptedBy { get; set; }

    public string? AcceptedByName { get; set; }

    public string? AcceptedInstitutionName { get; set; }

    public int? AcceptedInstitutionID { get; set; }

    public string? Clinicalsynopsis { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public bool IsDeleted { get; set; }
}
