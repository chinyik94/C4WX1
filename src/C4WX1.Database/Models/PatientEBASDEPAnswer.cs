using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class PatientEBASDEPAnswer
{
    public int PatientEBASDEPID_FK { get; set; }

    public int EBASDEPQuestionID_FK { get; set; }

    public int? Answer { get; set; }

    public virtual EBASDEPQuestion EBASDEPQuestionID_FKNavigation { get; set; } = null!;

    public virtual PatientEBASDEP PatientEBASDEPID_FKNavigation { get; set; } = null!;
}
