using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Package
{
    public int PackageID { get; set; }

    public string? PackageName { get; set; }

    public string? PackageDetails { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<PatientPackage> PatientPackage { get; set; } = new List<PatientPackage>();
}
