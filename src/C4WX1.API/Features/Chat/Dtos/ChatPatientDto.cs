namespace C4WX1.API.Features.Chat.Dtos;

public sealed class ChatPatientDto
{
    public int PatientID { get; set; }
    public string Firstname { get; set; } = null!;
    public string Lastname { get; set; } = null!;
    public string? Photo { get; set; }
}
