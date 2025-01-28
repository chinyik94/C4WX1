using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class DiseaseVitalSignType
{
    public int DiseaseVitalSignTypeID { get; set; }

    public int DiseaseID_FK { get; set; }

    public int VitalSignTypeID_FK { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Disease DiseaseID_FKNavigation { get; set; } = null!;

    public virtual VitalSignTypes VitalSignTypeID_FKNavigation { get; set; } = null!;
}
