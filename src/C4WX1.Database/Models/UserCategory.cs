using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class UserCategory
{
    public int UserCategoryID { get; set; }

    public string UserCategory1 { get; set; } = null!;

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public bool IsDeleted { get; set; }

    public int? UserCategoryOrganizationID_FK { get; set; }

    public bool? EnableGeoFencing { get; set; }

    public virtual ICollection<Event> Event { get; set; } = new List<Event>();

    public virtual ICollection<Task> Task { get; set; } = new List<Task>();

    public virtual ICollection<UserCategoryFacility> UserCategoryFacility { get; set; } = new List<UserCategoryFacility>();

    public virtual Code? UserCategoryOrganizationID_FKNavigation { get; set; }

    public virtual ICollection<UserCategoryParentChild> UserCategoryParentChildChildUserCategoryID_FKNavigation { get; set; } = new List<UserCategoryParentChild>();

    public virtual ICollection<UserCategoryParentChild> UserCategoryParentChildParentUserCategoryID_FKNavigation { get; set; } = new List<UserCategoryParentChild>();

    public virtual ICollection<UserCategoryRole> UserCategoryRole { get; set; } = new List<UserCategoryRole>();

    public virtual ICollection<UserType> UserType { get; set; } = new List<UserType>();
}
