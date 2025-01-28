using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class UserCategoryFacility
{
    public int UserCategoryID_FK { get; set; }

    public int FacilityID_FK { get; set; }

    public virtual Facility FacilityID_FKNavigation { get; set; } = null!;

    public virtual UserCategory UserCategoryID_FKNavigation { get; set; } = null!;
}
