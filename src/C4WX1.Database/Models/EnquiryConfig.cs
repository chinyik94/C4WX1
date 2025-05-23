﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class EnquiryConfig
{
    public int EnquiryConfigID { get; set; }

    public int? SCMID_FK { get; set; }

    public string? EmailContent { get; set; }

    public int? EscalatingPersonID_FK { get; set; }

    public decimal? EscalationPeriod { get; set; }

    public string? EscalationEmail { get; set; }

    public string? EmailtoCMContent { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<EnquiryEscPerson> EnquiryEscPerson { get; set; } = new List<EnquiryEscPerson>();

    public virtual ICollection<EnquirySCM> EnquirySCM { get; set; } = new List<EnquirySCM>();

    public virtual Users? EscalatingPersonID_FKNavigation { get; set; }

    public virtual Users? SCMID_FKNavigation { get; set; }
}