using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Otp
{
    public int OtpId { get; set; }

    public int UserId { get; set; }

    public string Password { get; set; } = null!;

    public DateTime CreatedDate { get; set; }
}
