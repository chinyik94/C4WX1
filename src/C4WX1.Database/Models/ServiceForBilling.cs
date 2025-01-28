﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class ServiceForBilling
{
    public int ServiceForBillingID { get; set; }

    public int CategoryID_FK { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Duration1 { get; set; } = null!;

    public string? Duration2 { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<BillingInvoiceService> BillingInvoiceService { get; set; } = new List<BillingInvoiceService>();

    public virtual ICollection<BillingProposalService> BillingProposalService { get; set; } = new List<BillingProposalService>();

    public virtual Code CategoryID_FKNavigation { get; set; } = null!;

    public virtual ICollection<ServiceForBillingCost> ServiceForBillingCost { get; set; } = new List<ServiceForBillingCost>();
}
