using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class AMTQuestion
{
    public int AMTQuestionId { get; set; }

    public string Question { get; set; } = null!;

    public int? Ordering { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<PatientAMTAnswer> PatientAMTAnswer { get; set; } = new List<PatientAMTAnswer>();
}
