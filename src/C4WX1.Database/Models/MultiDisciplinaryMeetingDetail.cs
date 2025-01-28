using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class MultiDisciplinaryMeetingDetail
{
    public int MultiDisciplinaryMeetingDetailID { get; set; }

    public int MultiDisciplinaryMeetingID_FK { get; set; }

    public int IssueCatID { get; set; }

    public string IssueTitle { get; set; } = null!;

    public string IssueContent { get; set; } = null!;

    public int ActionPlan { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public bool IsDeleted { get; set; }

    public virtual MultiDisciplinaryMeeting MultiDisciplinaryMeetingID_FKNavigation { get; set; } = null!;
}
