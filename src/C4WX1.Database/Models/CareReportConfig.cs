using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class CareReportConfig
{
    public int CareReportConfigID { get; set; }

    public int UserTypeID_FK { get; set; }

    public string? SectionAccess { get; set; }

    public bool IsDefault { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public virtual UserType UserTypeID_FKNavigation { get; set; } = null!;
}
