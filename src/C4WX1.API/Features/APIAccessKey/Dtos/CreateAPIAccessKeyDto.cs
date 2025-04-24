using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.APIAccessKey.Dtos;

public sealed class CreateAPIAccessKeyDto : CreateDto
{
    public string Code { get; set; } = string.Empty;
}
