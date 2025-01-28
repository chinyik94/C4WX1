using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class TaskUserLogAttachment
{
    public int FileAttachmentID { get; set; }

    public int TaskUserLogID_FK { get; set; }

    public string? FileName { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public bool IsDeleted { get; set; }

    public virtual TaskUserLog TaskUserLogID_FKNavigation { get; set; } = null!;
}
