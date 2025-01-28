﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Resource
{
    public int ResourceId { get; set; }

    public int CodeId { get; set; }

    public int LanguageId { get; set; }

    public string? CodeValue { get; set; }

    public string? Details { get; set; }

    public virtual Code Code { get; set; } = null!;

    public virtual Language Language { get; set; } = null!;
}
