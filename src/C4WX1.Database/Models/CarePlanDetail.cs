using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class CarePlanDetail
{
    public int CarePlanDetailID { get; set; }

    public int CarePlanSubID_FK { get; set; }

    public int SystemID_FK { get; set; }

    public int DiseaseID_FK { get; set; }

    public int? DiseaseSubInfoID_FK { get; set; }

    public virtual CarePlanSub CarePlanSubID_FKNavigation { get; set; } = null!;

    public virtual Disease DiseaseID_FKNavigation { get; set; } = null!;

    public virtual SystemForDisease SystemID_FKNavigation { get; set; } = null!;
}
