using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class NutritionTaskReference
{
    public int ReferenceID { get; set; }

    public int CodeId_FK { get; set; }

    public string? ReferenceImage { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public bool IsDeleted { get; set; }

    public int? Value { get; set; }

    public virtual Code CodeId_FKNavigation { get; set; } = null!;

    public virtual ICollection<NutritionTask> NutritionTaskAmountReferenceID_FKNavigation { get; set; } = new List<NutritionTask>();

    public virtual ICollection<NutritionTask> NutritionTaskColorReferenceID_FKNavigation { get; set; } = new List<NutritionTask>();

    public virtual ICollection<NutritionTask> NutritionTaskTypeReferenceID_FKNavigation { get; set; } = new List<NutritionTask>();
}
