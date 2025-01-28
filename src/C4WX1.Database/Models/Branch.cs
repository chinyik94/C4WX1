using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Branch
{
    public int BranchID { get; set; }

    public string BranchName { get; set; } = null!;

    public string? Address1 { get; set; }

    public string? Address2 { get; set; }

    public string? Address3 { get; set; }

    public string? Contact { get; set; }

    public string? Email { get; set; }

    public string Status { get; set; } = null!;

    public bool IsSystemUsed { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public bool IsDeleted { get; set; }

    public int? CurrencyID_FK { get; set; }

    public virtual Code? CurrencyID_FKNavigation { get; set; }

    public virtual ICollection<UserBranch> UserBranch { get; set; } = new List<UserBranch>();
}
