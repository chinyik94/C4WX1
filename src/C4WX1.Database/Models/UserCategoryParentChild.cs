﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class UserCategoryParentChild
{
    public int ParentUserCategoryID_FK { get; set; }

    public int ChildUserCategoryID_FK { get; set; }

    public virtual UserCategory ChildUserCategoryID_FKNavigation { get; set; } = null!;

    public virtual UserCategory ParentUserCategoryID_FKNavigation { get; set; } = null!;
}
