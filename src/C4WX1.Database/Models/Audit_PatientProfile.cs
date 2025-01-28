using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_PatientProfile
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int PatientProfileID { get; set; }

    public int? BloodTypeID_FK { get; set; }

    public int? ReligionID_FK { get; set; }

    public string? MobilePhone { get; set; }

    public string? HomePhone { get; set; }

    public string? Email { get; set; }

    public string? BillingAddress1 { get; set; }

    public string? BillingAddress2 { get; set; }

    public string? BillingAddress3 { get; set; }

    public string? BillingPostalCode { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public string? OtherReligion { get; set; }

    public string? Organization { get; set; }

    public string? Location { get; set; }

    public string? Ward { get; set; }

    public string? Bed { get; set; }

    public string? Note { get; set; }

    public int? PatientOrganizationID_FK { get; set; }
}
