using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_BillingInvoiceService
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

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
}
