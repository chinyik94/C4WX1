﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class PatientWoundDraftTreatmentList
{
    public int PatientWoundDraftTListID { get; set; }

    public int PatientWoundDraftID_FK { get; set; }

    public int TListItemID_FK { get; set; }

    public string? Remarks { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public virtual PatientWoundDraft PatientWoundDraftID_FKNavigation { get; set; } = null!;

    public virtual TreatmentListItem TListItemID_FKNavigation { get; set; } = null!;
}
