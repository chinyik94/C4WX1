using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class EnquirySCM
{
    public int EnquiryConfigID_FK { get; set; }

    public int UserID_FK { get; set; }

    public virtual EnquiryConfig EnquiryConfigID_FKNavigation { get; set; } = null!;

    public virtual Users UserID_FKNavigation { get; set; } = null!;
}
