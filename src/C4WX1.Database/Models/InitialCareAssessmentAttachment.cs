using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class InitialCareAssessmentAttachment
{
    public int InitialCareAssessmentAttachmentID { get; set; }

    public int InitialCareAssessmentID_FK { get; set; }

    public string? Filename { get; set; }

    public string? Physical { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public bool IsReferralAssessment { get; set; }

    public bool IsDischargeAssessment { get; set; }

    public bool IsDeleted { get; set; }

    public virtual InitialCareAssessment InitialCareAssessmentID_FKNavigation { get; set; } = null!;
}
