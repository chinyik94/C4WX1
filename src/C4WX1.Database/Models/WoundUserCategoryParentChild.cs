using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class WoundUserCategoryParentChild
{
    public int ParentUserCategoryID_FK { get; set; }

    public int ChildUserCategoryID_FK { get; set; }
}
