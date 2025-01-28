﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_SyncPatientLog
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int SyncLogId { get; set; }

    public int SyncBatchTs { get; set; }

    public int PatientID { get; set; }

    public int OffPatientID { get; set; }

    public int? ServerPatientID { get; set; }

    public bool SyncResult { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }
}
