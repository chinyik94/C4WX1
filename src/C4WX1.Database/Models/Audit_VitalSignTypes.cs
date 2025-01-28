﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_VitalSignTypes
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int id { get; set; }

    public string name { get; set; } = null!;

    public bool isDeleted { get; set; }

    public int? createdBy { get; set; }

    public DateTime createdDate { get; set; }

    public int? updatedBy { get; set; }

    public DateTime? updatedDate { get; set; }
}
