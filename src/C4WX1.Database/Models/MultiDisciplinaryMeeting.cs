﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class MultiDisciplinaryMeeting
{
    public int MultiDisciplinaryMeetingID { get; set; }

    public int PatientID_FK { get; set; }

    public string IssuesOverall { get; set; } = null!;

    public int AssignedToFollowUp { get; set; }

    public string Remarks { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public int CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<MultiDisciplinaryMeetingDetail> MultiDisciplinaryMeetingDetail { get; set; } = new List<MultiDisciplinaryMeetingDetail>();

    public virtual Patient PatientID_FKNavigation { get; set; } = null!;
}
