using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.EmailLog.Dtos;

public sealed class GetEmailLogListDto : GetListDto
{
    [QueryParam]
    public string? MsgFrom { get; set; }

    [QueryParam]
    public string? MsgFromName { get; set; }

    [QueryParam]
    public string? MsgTo { get; set; }

    [QueryParam]
    public string? MsgSubj { get; set; }

    [QueryParam]
    public string? IsSent { get; set; }

    [QueryParam]
    public DateTime FromDate { get; set; }

    [QueryParam]
    public DateTime ToDate { get; set; }
}
