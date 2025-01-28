using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class EnquiryAttachment
{
    public int EnquiryAttachmentID { get; set; }

    public int EnquiryID_FK { get; set; }

    public string? Filename { get; set; }

    public string? Physical { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public bool IsDeleted { get; set; }

    public string? Type { get; set; }

    public virtual Enquiry EnquiryID_FKNavigation { get; set; } = null!;
}
