﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_Types
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public string code { get; set; } = null!;

    public string codeValue { get; set; } = null!;

    public string? parentCode { get; set; }

    public int ordering { get; set; }

    public DateTime created { get; set; }

    public DateTime? updated { get; set; }
}
