using FastEndpoints;

namespace C4WX1.API.Features.APIAccessKey.Dtos;

public class GetAPIAccessKeyByCodeDto
{
    public string Code { get; set; } = null!;
    [QueryParam]
    public int UserId { get; set; }
}
