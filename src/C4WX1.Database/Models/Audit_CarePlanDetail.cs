﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_CarePlanDetail
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int CarePlanDetailID { get; set; }

    public int CarePlanSubID_FK { get; set; }

    public int SystemID_FK { get; set; }

    public int DiseaseID_FK { get; set; }

    public int? DiseaseSubInfoID_FK { get; set; }
}