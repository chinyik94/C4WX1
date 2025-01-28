using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class UserType
{
    public int UserTypeID { get; set; }

    public string UserType1 { get; set; } = null!;

    public int UserCategoryID_FK { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public bool IsDeleted { get; set; }

    public decimal? ManpowerRate { get; set; }

    public virtual ICollection<CareReportConfig> CareReportConfig { get; set; } = new List<CareReportConfig>();

    public virtual ICollection<ExternalDoctor> ExternalDoctor { get; set; } = new List<ExternalDoctor>();

    public virtual ICollection<MailSettingsMsgToUserType> MailSettingsMsgToUserType { get; set; } = new List<MailSettingsMsgToUserType>();

    public virtual UserCategory UserCategoryID_FKNavigation { get; set; } = null!;

    public virtual ICollection<UserUserType> UserUserType { get; set; } = new List<UserUserType>();
}
