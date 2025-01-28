using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class UserLanguage
{
    public int UserID_FK { get; set; }

    public int LanguageID_FK { get; set; }

    public virtual Code LanguageID_FKNavigation { get; set; } = null!;

    public virtual Users UserID_FKNavigation { get; set; } = null!;
}
