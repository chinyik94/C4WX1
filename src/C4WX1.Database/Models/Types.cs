﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Types
{
    public string code { get; set; } = null!;

    public string codeValue { get; set; } = null!;

    public string? parentCode { get; set; }

    public int ordering { get; set; }

    public DateTime created { get; set; }

    public DateTime? updated { get; set; }

    public virtual ICollection<APIAccessKey> APIAccessKey { get; set; } = new List<APIAccessKey>();

    public virtual ICollection<Types> InverseparentCodeNavigation { get; set; } = new List<Types>();

    public virtual ICollection<NotificationMessageTemplates> NotificationMessageTemplates { get; set; } = new List<NotificationMessageTemplates>();

    public virtual ICollection<Notifications> Notifications { get; set; } = new List<Notifications>();

    public virtual Types? parentCodeNavigation { get; set; }
}
