namespace C4WX1.API.Features.RegisteredDeviceV2.Dtos;

public sealed class UpdateRegisteredDeviceV2AppNameAndVersionDto
{
    public string DeviceId { get; set; } = null!;
    public int UserId { get; set; }
    public string? AppName { get; set; }
    public string? Version { get; set; }
}
