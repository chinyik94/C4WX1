﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class ServiceForBillingCost
{
    public int ServiceForBillingCostID { get; set; }

    public int ServiceForBillingID_FK { get; set; }

    public int CurrencyID_FK { get; set; }

    public decimal UnitCost { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Code CurrencyID_FKNavigation { get; set; } = null!;

    public virtual ServiceForBilling ServiceForBillingID_FKNavigation { get; set; } = null!;
}
