using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class MailSettingsMsgToUserType
{
    public int MailSetting_FK { get; set; }

    public int UserTypeID_FK { get; set; }

    public virtual MailSettings MailSetting_FKNavigation { get; set; } = null!;

    public virtual UserType UserTypeID_FKNavigation { get; set; } = null!;
}
