namespace C4WX1.API.Features.RegisteredDeviceV2.Dtos;

public sealed class RegisteredDeviceV2Dto
{
    public int RegisteredDeviceID { get; set; }
    public int? UserID_FK { get; set; }
    public string? DeviceId { get; set; }
    public string? DeviceName { get; set; }
    public string? AppName { get; set; }
    public string? Version { get; set; }
    public string? DeviceType { get; set; }
    public string? DeviceToken { get; set; }
    public string? FirstRegisterIpAddress { get; set; }
    public string? Status { get; set; }
    public string? Remarks { get; set; }
    public DateTime CreatedDate { get; set; }
    public int CreatedBy_FK { get; set; }
    public RegisteredDeviceV2UserDto? CreatedBy { get; set; } = null!;
    public DateTime? ModifiedDate { get; set; }
    public int? ModifiedBy_FK { get; set; }
    public RegisteredDeviceV2UserDto? ModifiedBy { get; set; }
}

public sealed class RegisteredDeviceV2UserDto
{
    public int UserId { get; set; }
    public string Firstname { get; set; } = null!;
    public string Lastname { get; set; } = null!;
    public string? Photo { get;set; }
}

