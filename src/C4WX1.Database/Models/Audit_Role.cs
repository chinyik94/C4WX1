﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_Role
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int RoleId { get; set; }

    public string RoleDescription { get; set; } = null!;

    public string OptionText { get; set; } = null!;

    public string OptionValue { get; set; } = null!;

    public string OptionType { get; set; } = null!;

    public int Ordering { get; set; }

    public DateTime DateCreated { get; set; }

    public bool? Active { get; set; }
}
