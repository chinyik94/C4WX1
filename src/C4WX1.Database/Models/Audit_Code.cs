using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_Code
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int CodeId { get; set; }

    public int CodeTypeId_FK { get; set; }

    public string CodeName { get; set; } = null!;

    public int? Ordering { get; set; }

    public bool IsSystemUsed { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public bool? Indication_Acute { get; set; }

    public bool? Indication_PRN { get; set; }

    public string? Referral_Code { get; set; }

    public bool? AllergyReaction_Drug { get; set; }

    public bool? AllergyReaction_Others { get; set; }

    public int? MedicationGroupID_FK { get; set; }

    public string? Status { get; set; }

    public string? CurrencyCodeA { get; set; }

    public string? CurrencyCodeN { get; set; }

    public string? CurrencyInvoiceFooter { get; set; }

    public bool? Critical { get; set; }
}
