using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class ErrorLog
{
    public int ErrorLogId { get; set; }

    public string ErrorDetails { get; set; } = null!;

    public DateTime DateCreated { get; set; }
}
