using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class TreatmentListItem
{
    public int TListItemID { get; set; }

    public string ItemName { get; set; } = null!;

    public int TListTypeID_FK { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsSystemUsed { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public string? ItemBrand { get; set; }

    public decimal? Cost { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public virtual ICollection<PatientWoundDraftTreatmentList> PatientWoundDraftTreatmentList { get; set; } = new List<PatientWoundDraftTreatmentList>();

    public virtual ICollection<PatientWoundVisitTreatmentList> PatientWoundVisitTreatmentList { get; set; } = new List<PatientWoundVisitTreatmentList>();

    public virtual Code TListTypeID_FKNavigation { get; set; } = null!;

    public virtual ICollection<TreatmentTOL> TreatmentTOL { get; set; } = new List<TreatmentTOL>();
}
