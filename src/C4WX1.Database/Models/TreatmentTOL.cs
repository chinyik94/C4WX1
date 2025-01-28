using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class TreatmentTOL
{
    public int TreatmentTOLID { get; set; }

    public int TListItemID_FK { get; set; }

    public virtual TreatmentListItem TListItemID_FKNavigation { get; set; } = null!;
}
