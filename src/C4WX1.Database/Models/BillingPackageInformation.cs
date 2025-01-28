using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class BillingPackageInformation
{
    public int BillingPackageID { get; set; }

    public int BillingServiceID { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public bool IsDeleted { get; set; }

    public int Session { get; set; }
}
