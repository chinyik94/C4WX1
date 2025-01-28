﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class CareReportSocialSupport
{
    public int CareReportSocialSupportID { get; set; }

    public int CareReportID_FK { get; set; }

    public int PatientSocialSupportID_FK { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public virtual CareReport CareReportID_FKNavigation { get; set; } = null!;

    public virtual PatientSocialSupport PatientSocialSupportID_FKNavigation { get; set; } = null!;
}
