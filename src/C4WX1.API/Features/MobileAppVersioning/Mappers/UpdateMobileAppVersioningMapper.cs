using C4WX1.API.Features.MobileAppVersioning.Dtos;

namespace C4WX1.API.Features.MobileAppVersioning.Mappers;

public class UpdateMobileAppVersioningMapper
    : RequestMapper<UpdateMobileAppVersioningDto, Database.Models.MobileAppVersioning>
{
    public override Database.Models.MobileAppVersioning UpdateEntity(
        UpdateMobileAppVersioningDto r, 
        Database.Models.MobileAppVersioning e)
    {
        e.AppName = r.AppName;
        e.DeviceType = r.DeviceType;
        e.Version = r.Version;
        e.Status = r.Status;
        e.ModifiedBy_FK = r.UserId;
        e.ModifiedDate = DateTime.Now;

        return e;
    }
}
