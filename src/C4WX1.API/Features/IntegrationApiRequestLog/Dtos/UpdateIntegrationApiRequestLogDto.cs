using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.IntegrationApiRequestLog.Dtos;

public sealed class UpdateIntegrationApiRequestLogDto : UpdateDto
{
    public string Status { get; set; } = null!;
}
