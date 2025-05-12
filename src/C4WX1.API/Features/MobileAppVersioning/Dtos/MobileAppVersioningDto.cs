namespace C4WX1.API.Features.MobileAppVersioning.Dtos;

public sealed class MobileAppVersioningDto
{
    public int MobileVersionId { get; set; }
    public string? AppName { get; set; }
    public string? DeviceType { get; set; }
    public string? Version { get; set; }
    public string? Status { get; set; }
    public DateTime? CreatedDate { get; set; }
    public int? CreatedBy_FK { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public int? ModifiedBy_FK { get; set; }
    public MobileAppVersioningUserDto? CreatedBy { get; set; }
    public MobileAppVersioningUserDto? ModifiedBy { get; set; }
}
