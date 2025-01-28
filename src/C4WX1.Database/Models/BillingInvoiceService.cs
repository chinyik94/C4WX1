using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class BillingInvoiceService
{
    public int BillingInvoiceServiceID { get; set; }

    public int BillingInvoiceID_FK { get; set; }

    public int? ProposalID_FK { get; set; }

    public int ServiceID_FK { get; set; }

    public decimal UnitCost { get; set; }

    public int Session { get; set; }

    public decimal Discount { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public bool IsDeleted { get; set; }

    public virtual BillingInvoice BillingInvoiceID_FKNavigation { get; set; } = null!;

    public virtual BillingProposal? ProposalID_FKNavigation { get; set; }

    public virtual ServiceForBilling ServiceID_FKNavigation { get; set; } = null!;
}
