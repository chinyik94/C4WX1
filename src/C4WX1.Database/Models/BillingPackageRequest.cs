﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class BillingPackageRequest
{
    public int PackageRequestID { get; set; }

    public string PackageRequestNo { get; set; } = null!;

    public int PatientID_FK { get; set; }

    public string PatientName { get; set; } = null!;

    public string SendBillTo { get; set; } = null!;

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public bool Discount { get; set; }

    public string? DiscountType { get; set; }

    public decimal DiscountAmt { get; set; }

    public decimal DiscountPercentage { get; set; }

    public string Remarks { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public int CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public bool IsDeleted { get; set; }

    public string? BillingAddress1 { get; set; }

    public string? BillingAddress2 { get; set; }

    public string? BillingAddress3 { get; set; }

    public string? BillingPostalCode { get; set; }

    public decimal TotalPackageAmount { get; set; }

    public string? Email { get; set; }

    public string? PackageList { get; set; }
}
