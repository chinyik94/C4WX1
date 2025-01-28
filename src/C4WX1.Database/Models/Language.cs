using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Language
{
    public int LanguageId { get; set; }

    public string? Name { get; set; }

    public string? FullName { get; set; }

    public virtual ICollection<Resource> Resource { get; set; } = new List<Resource>();
}
