using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.RegisteredDeviceV2.Dtos;

public sealed class UpdateRegisteredDeviceV2Dto : UpdateDto
{
    public string? DeviceId { get; set; }
    public string? DeviceName { get; set; }
    public string? AppName { get; set; }
    public string? Version { get; set; }
    public string? DeviceType { get; set; }
    public string? DeviceToken { get; set; }
    public string? FirstRegisterIpAddress { get; set; }
    public string? Remarks { get; set; }
}
