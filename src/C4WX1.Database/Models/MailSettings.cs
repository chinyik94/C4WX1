using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class MailSettings
{
    public int id { get; set; }

    public string description { get; set; } = null!;

    public string? msgBCC { get; set; }

    public string? msgCC { get; set; }

    public string? msgTo { get; set; }

    public string? msgSubj { get; set; }

    public string? msgBody { get; set; }

    public bool? displayMsgTo { get; set; }

    public bool? displayMsgCC { get; set; }

    public bool? displayMsgBCC { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<MailSettingsMsgToUserType> MailSettingsMsgToUserType { get; set; } = new List<MailSettingsMsgToUserType>();

    public virtual ICollection<WoundConsolidatedEmail> WoundConsolidatedEmail { get; set; } = new List<WoundConsolidatedEmail>();
}
