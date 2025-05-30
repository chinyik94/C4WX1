﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_Users
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int UserId { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string? Remarks { get; set; }

    public string? Photo { get; set; }

    public string? Contact { get; set; }

    public string? Designation { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public DateTime? LastLoginDate { get; set; }

    public DateTime? LastLogoutDate { get; set; }

    public DateTime? LastActivityDate { get; set; }

    public DateTime? LastLockoutDate { get; set; }

    public DateTime? LastPasswordChangedDate { get; set; }

    public string? PreviousPasswords { get; set; }

    public string? SessionKey { get; set; }

    public bool? ResetPassword { get; set; }

    public bool IsDeleted { get; set; }

    public string? LocationNow1 { get; set; }

    public string? LocationNow2 { get; set; }

    public string? LocationNow3 { get; set; }

    public string? PostalCodeNow { get; set; }

    public DateTime? LocationNowModifiedDate { get; set; }

    public int? PatientID_FK { get; set; }

    public bool? IsExternal { get; set; }

    public int? UserOrganizationID_FK { get; set; }

    public bool? IsTCAccepted { get; set; }

    public string? UserName { get; set; }

    public int? PreferredLanguage { get; set; }

    public int? AccessLevelID_FK { get; set; }

    public bool HasValidEmail { get; set; }

    public string? TokenID { get; set; }

    public string? PreviousPasswords2 { get; set; }

    public bool? SharePdf { get; set; }
}