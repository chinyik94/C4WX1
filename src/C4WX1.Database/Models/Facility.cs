using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Facility
{
    public int FacilityID { get; set; }

    public string FacilityName { get; set; } = null!;

    public int OrganizationID_FK { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public string? _id { get; set; }

    public string? IntegrationSource { get; set; }

    public string? Remarks { get; set; }

    public virtual ICollection<Notifications> Notifications { get; set; } = new List<Notifications>();

    public virtual Code OrganizationID_FKNavigation { get; set; } = null!;

    public virtual ICollection<PatientFacility> PatientFacility { get; set; } = new List<PatientFacility>();

    public virtual ICollection<UserCategoryFacility> UserCategoryFacility { get; set; } = new List<UserCategoryFacility>();
}
