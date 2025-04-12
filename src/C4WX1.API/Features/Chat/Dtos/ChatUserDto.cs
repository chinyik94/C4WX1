namespace C4WX1.API.Features.Chat.Dtos;

public sealed class ChatUserDto
{
    public int UserId { get; set; }
    public string Firstname { get; set; } = null!;
    public string Lastname { get; set; } = null!;
    public string? Photo { get; set; }
}
