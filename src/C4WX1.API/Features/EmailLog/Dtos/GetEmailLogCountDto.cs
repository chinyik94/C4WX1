using FastEndpoints;

namespace C4WX1.API.Features.EmailLog.Dtos;

public class GetEmailLogCountDto
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
