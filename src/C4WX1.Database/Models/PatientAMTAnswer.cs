using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class PatientAMTAnswer
{
    public int PatientAMTID_FK { get; set; }

    public int AMTQuestionID_FK { get; set; }

    public int? Answer { get; set; }

    public virtual AMTQuestion AMTQuestionID_FKNavigation { get; set; } = null!;

    public virtual PatientAMT PatientAMTID_FKNavigation { get; set; } = null!;
}
