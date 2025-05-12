using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.MailSettings.Dtos;

public sealed class UpdateMailSettingsDto : UpdateDto
{
    public string description { get; set; } = null!;
    public string? msgBCC { get; set; }
    public string? msgCC { get; set; }
    public string? msgTo { get; set; }
    public string? msgSubj { get; set; }
    public string? msgBody { get; set; }
    public bool? displayMsgTo { get; set; }
    public bool? displayMsgCC { get; set; }
    public bool? displayMsgBCC { get; set; }
    public ICollection<int> recipientUserType { get; set; } = [];
}
