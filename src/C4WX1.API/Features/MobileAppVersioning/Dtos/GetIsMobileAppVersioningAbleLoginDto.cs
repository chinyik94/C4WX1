namespace C4WX1.API.Features.MobileAppVersioning.Dtos;

public sealed class GetIsMobileAppVersioningAbleLoginDto
{
    [QueryParam]
    public string AppName { get; set; } = null!;

    [QueryParam]
    public string DeviceType { get; set; } = null!;

    [QueryParam]
    public string Version { get; set; } = null!;
}
