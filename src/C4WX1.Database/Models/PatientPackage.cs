﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class PatientPackage
{
    public int PatientID_FK { get; set; }

    public int PackageID_FK { get; set; }

    public virtual Package PackageID_FKNavigation { get; set; } = null!;

    public virtual Patient PatientID_FKNavigation { get; set; } = null!;
}