﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_ServiceSkillset
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int ServiceID_FK { get; set; }

    public int SkillsetID_FK { get; set; }
}
