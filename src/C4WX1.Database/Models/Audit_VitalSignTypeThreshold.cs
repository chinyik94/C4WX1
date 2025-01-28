using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_VitalSignTypeThreshold
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int VitalSignTypeID_FK { get; set; }

    public decimal? ews_min_1 { get; set; }

    public decimal? ews_max_1 { get; set; }

    public decimal? ews_min_2 { get; set; }

    public decimal? ews_max_2 { get; set; }

    public decimal? ews_min_3 { get; set; }

    public decimal? ews_max_3 { get; set; }

    public decimal? ews_min_4 { get; set; }

    public decimal? ews_max_4 { get; set; }

    public decimal? ews_min_5 { get; set; }

    public decimal? ews_max_5 { get; set; }

    public decimal? ews_min_6 { get; set; }

    public decimal? ews_max_6 { get; set; }

    public decimal? ews_min_7 { get; set; }

    public decimal? ews_max_7 { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }
}
