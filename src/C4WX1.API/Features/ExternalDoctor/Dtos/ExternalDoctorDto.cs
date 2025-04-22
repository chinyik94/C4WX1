namespace C4WX1.API.Features.ExternalDoctor.Dtos;

public sealed class ExternalDoctorDto
{
    public int ExternalDoctorID { get; set; }
    public string Name { get; set; } = null!;
    public string? Email { get; set; }
    public string? Contact { get; set; }
    public int? ClinicianTypeID_FK { get; set; }
    public string? ClinicianTypeName { get; set; }
    public bool CanDelete { get; set; }
}
