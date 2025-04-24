using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.C4WDeviceToken.Dtos;

public sealed class UpdateC4WDeviceTokenDto : UpdateDto
{
    public string? OldDeviceToken { get; set; }
    public string? NewDeviceToken { get; set; }
    public string? ClientEnvironment { get; set; }
    public string? Device { get; set; }
}
