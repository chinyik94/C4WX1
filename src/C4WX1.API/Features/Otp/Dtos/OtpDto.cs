namespace C4WX1.API.Features.Otp.Dtos;

public sealed class OtpDto
{
    public int OtpId { get; set; }
    public int UserId { get; set; }
    public string Password { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
    public bool IsActive { get; set; }
}
