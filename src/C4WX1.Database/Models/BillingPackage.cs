using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class BillingPackage
{
    public int ID { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Type { get; set; }

    public int? Session { get; set; }

    public decimal? TotalPrice { get; set; }

    public decimal? UnitPrice { get; set; }

    public int? Validity { get; set; }

    public string? Status { get; set; }

    public string? Remarks { get; set; }

    public int BillingServiceID { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public bool IsDeleted { get; set; }

    public virtual BillingService BillingService { get; set; } = null!;
}
