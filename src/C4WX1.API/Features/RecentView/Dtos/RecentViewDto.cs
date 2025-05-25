namespace C4WX1.API.Features.RecentView.Dtos;

public sealed class RecentViewDto
{
    public int PatientID { get; set; }
    public string Firstname { get; set; } = null!;
    public string Lastname { get; set; } = null!;
    public DateTime? DateOfBirth { get; set; }
    public string? IdentificationNumber { get; set; }
    public string? Status { get; set; }
    public string? Photo { get; set; }
    public RecentViewPatientProfileDto? Profile { get; set; }
    public ICollection<RecentViewClinicianDto> ClinicianList { get; set; } = [];
}

public sealed class RecentViewPatientProfileDto
{
    public string? MobilePhone { get; set; }
    public string? HomePhone { get; set; }
    public string? Email { get; set; }
}

public sealed class RecentViewClinicianDto
{
    public int PatientClinicianID { get; set; }
    public int? UserID_FK { get; set; }
    public int? ExternalDoctorID_FK { get; set; }
    public RecentViewClinicianUserDto? UserData { get; set; }
    public RecentViewExternalDoctorDto? ExternalDoctorData { get; set; }
}

public sealed class RecentViewClinicianUserDto
{
    public int? UserId { get; set; }
    public string Firstname { get; set; } = null!;
    public string Lastname { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Contact { get; set; }
    public string? Photo { get; set; }
}

public sealed class RecentViewExternalDoctorDto
{
    public int? ExternalDoctorID { get; set; }
    public string Name { get; set; } = null!;
    public string? Contact { get; set; } 
    public string? Email { get; set; } 
    public int? ClinicianTypeID_FK { get; set; }
    public string? ClinicianTypeName { get; set; } 
}