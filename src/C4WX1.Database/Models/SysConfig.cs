using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class SysConfig
{
    public string ConfigName { get; set; } = null!;

    public string? ConfigValue { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public bool? IsConfigurable { get; set; }

    public string? Description { get; set; }
}
