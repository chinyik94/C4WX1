﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class ReceiptForInvoice
{
    public int ReceiptForInvoiceID { get; set; }

    public int ReceiptID_FK { get; set; }

    public int BillingInvoiceID_FK { get; set; }

    public decimal Amt { get; set; }

    public virtual BillingInvoice BillingInvoiceID_FKNavigation { get; set; } = null!;

    public virtual Receipt ReceiptID_FKNavigation { get; set; } = null!;
}
