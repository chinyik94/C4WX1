﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class EnquiryEscPerson
{
    public int EnquiryConfigID { get; set; }

    public int UserID_FK { get; set; }

    public virtual EnquiryConfig EnquiryConfig { get; set; } = null!;

    public virtual Users UserID_FKNavigation { get; set; } = null!;
}