namespace C4WX1.API.Features.ExternalDoctor.Dtos;

public sealed class ChangeExternalDoctorToUserDto
{
    public string ExternalName { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public int UserId { get; set; }
}
