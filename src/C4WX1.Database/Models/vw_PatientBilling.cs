using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class vw_PatientBilling
{
    public int? PatientProfileID_FK { get; set; }

    public string? PatientName { get; set; }

    public string? Email { get; set; }

    public string? BillingAddress1 { get; set; }

    public string? BillingAddress2 { get; set; }

    public string? BillingAddress3 { get; set; }

    public string? BillingPostalCode { get; set; }
}
