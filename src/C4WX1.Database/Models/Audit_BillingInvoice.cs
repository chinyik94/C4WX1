using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_BillingInvoice
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int BillingInvoiceID { get; set; }

    public int PatientID_FK { get; set; }

    public string InvoiceNumber { get; set; } = null!;

    public DateTime? InvoiceDueDate { get; set; }

    public string? CaseNumber { get; set; }

    public int? InitialCareAssessmentID_FK { get; set; }

    public int? CareReportID_FK { get; set; }

    public bool? Consumable { get; set; }

    public bool? SendEmail { get; set; }

    public bool? EmailPatient { get; set; }

    public string? EmailTo { get; set; }

    public string? EmailCC { get; set; }

    public string? EmailBCC { get; set; }

    public int CurrencyID_FK { get; set; }

    public decimal TotalCost { get; set; }

    public string Status { get; set; } = null!;

    public string GroupNumber { get; set; } = null!;

    public short Version { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? InvoiceDate { get; set; }
}
