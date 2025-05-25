using C4WX1.API.Features.RegisteredDeviceV2.Dtos;

namespace C4WX1.API.Features.RegisteredDeviceV2.Mappers;

public class UpdateRegisteredDeviceV2AppNameAndVersionMapper
    : RequestMapper<UpdateRegisteredDeviceV2AppNameAndVersionDto, Database.Models.RegisteredDeviceV2>
{
    public override Database.Models.RegisteredDeviceV2 UpdateEntity(
        UpdateRegisteredDeviceV2AppNameAndVersionDto r, 
        Database.Models.RegisteredDeviceV2 e)
    {
        e.AppName = r.AppName;
        e.Version = r.Version;
        e.ModifiedBy_FK = r.UserId;
        e.ModifiedDate = DateTime.Now;

        return e;
    }
}
