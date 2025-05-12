using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.MobileAppVersioning.Dtos;

public sealed class UpdateMobileAppVersioningStatusDto : UpdateDto
{
    public string Status { get; set; } = null!;
}
