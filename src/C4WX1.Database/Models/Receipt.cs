using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Receipt
{
    public int ReceiptID { get; set; }

    public string ReceiptNumber { get; set; } = null!;

    public DateTime ReceiptDate { get; set; }

    public int PatientID_FK { get; set; }

    public int PaymentModeID_FK { get; set; }

    public decimal TotalAmt { get; set; }

    public string? ReceivedFrom { get; set; }

    public string? Remarks { get; set; }

    public bool? SendEmail { get; set; }

    public bool? EmailPatient { get; set; }

    public string? EmailTo { get; set; }

    public string? EmailCC { get; set; }

    public string? EmailBCC { get; set; }

    public int CurrencyID_FK { get; set; }

    public string Status { get; set; } = null!;

    public string GroupNumber { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public int CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Users CreatedBy_FKNavigation { get; set; } = null!;

    public virtual Code CurrencyID_FKNavigation { get; set; } = null!;

    public virtual Users? ModifiedBy_FKNavigation { get; set; }

    public virtual Patient PatientID_FKNavigation { get; set; } = null!;

    public virtual Code PaymentModeID_FKNavigation { get; set; } = null!;

    public virtual ICollection<ReceiptForInvoice> ReceiptForInvoice { get; set; } = new List<ReceiptForInvoice>();
}
