using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class SyncWoundLog
{
    public int SyncLogId { get; set; }

    public int SyncBatchTs { get; set; }

    public int WoundID { get; set; }

    public int OffWoundID { get; set; }

    public int ServerPatientID { get; set; }

    public int ServerWoundID { get; set; }

    public bool SyncResult { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }
}
