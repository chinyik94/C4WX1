﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_ReceiptForInvoice
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int ReceiptForInvoiceID { get; set; }

    public int ReceiptID_FK { get; set; }

    public int BillingInvoiceID_FK { get; set; }

    public decimal Amt { get; set; }
}
