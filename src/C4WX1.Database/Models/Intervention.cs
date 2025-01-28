using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Intervention
{
    public int InterventionID { get; set; }

    public int DiseaseID_FK { get; set; }

    public string InterventionInfo { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public virtual ICollection<CarePlanSubIntervention> CarePlanSubIntervention { get; set; } = new List<CarePlanSubIntervention>();

    public virtual Disease DiseaseID_FKNavigation { get; set; } = null!;
}
