using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.ExternalDoctor.Dtos;

public sealed class CreateExternalDoctorDto : CreateDto
{
    public string Name { get; set; } = null!;
    public string? Email { get; set; }
    public string? Contact { get; set; }
    public int? ClinicianTypeID_FK { get; set; }
}
