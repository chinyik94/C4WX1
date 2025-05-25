using C4WX1.API.Features.RegisteredDeviceV2.Dtos;

namespace C4WX1.API.Features.RegisteredDeviceV2.Mappers;

public class UpdateRegisteredDeviceV2Mapper
    : RequestMapper<UpdateRegisteredDeviceV2Dto, Database.Models.RegisteredDeviceV2>
{
    public override Database.Models.RegisteredDeviceV2 UpdateEntity(
        UpdateRegisteredDeviceV2Dto r, 
        Database.Models.RegisteredDeviceV2 e)
    {
        e.UserId_FK = r.UserId;
        e.DeviceId = r.DeviceId;
        e.DeviceName = r.DeviceName;
        e.DeviceType = r.DeviceType;
        e.DeviceToken = r.DeviceToken;
        e.FirstRegisterIpAddress = r.FirstRegisterIpAddress;
        e.Remarks = r.Remarks;
        e.AppName = r.AppName;
        e.Version = r.Version;
        e.ModifiedBy_FK = r.UserId;
        e.ModifiedDate = DateTime.Now;

        return e;
    }
}
