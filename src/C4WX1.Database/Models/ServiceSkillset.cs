using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class ServiceSkillset
{
    public int ServiceID_FK { get; set; }

    public int SkillsetID_FK { get; set; }

    public virtual Code ServiceID_FKNavigation { get; set; } = null!;

    public virtual Code SkillsetID_FKNavigation { get; set; } = null!;
}
