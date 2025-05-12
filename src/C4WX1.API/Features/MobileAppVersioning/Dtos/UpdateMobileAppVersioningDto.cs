using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.MobileAppVersioning.Dtos;

public sealed class UpdateMobileAppVersioningDto : UpdateDto
{
    public string? AppName { get; set; }
    public string? DeviceType { get; set; }
    public string? Version { get; set; }
    public string? Status { get; set; }
}
