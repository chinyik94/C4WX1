using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Diagnosis
{
    public int DiagnosisID { get; set; }

    public string Diagnosis1 { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public virtual ICollection<CarePlan> CarePlan { get; set; } = new List<CarePlan>();
}
