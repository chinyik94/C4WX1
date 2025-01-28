﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class APIAccessKey
{
    public int APIAccessKeyID { get; set; }

    public string TokenCode { get; set; } = null!;

    public string AccessKey { get; set; } = null!;

    public DateTime ExpiryDate { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UserId_FK { get; set; }

    public virtual Types TokenCodeNavigation { get; set; } = null!;
}
