using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class vw_UserRoles
{
    public int? UserId { get; set; }

    public string? Email { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public int? UserTypeID { get; set; }

    public string? UserType { get; set; }

    public int? UserCategoryID_FK { get; set; }

    public int? RoleID_FK { get; set; }

    public string? UserRole { get; set; }

    public string? UserCategory { get; set; }

    public string? RoleDescription { get; set; }

    public string? Status { get; set; }

    public bool? EnableGeoFencing { get; set; }
}
