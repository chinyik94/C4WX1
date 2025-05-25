using C4WX1.API.Features.RegisteredDeviceV2.Dtos;

namespace C4WX1.API.Features.RegisteredDeviceV2.Mappers;

public class RegisteredDeviceV2Mapper
    : ResponseMapper<RegisteredDeviceV2Dto, Database.Models.RegisteredDeviceV2>
{
    public override RegisteredDeviceV2Dto FromEntity(Database.Models.RegisteredDeviceV2 e)
        => new()
        {
            RegisteredDeviceID = e.RegisteredDeviceID,
            UserID_FK = e.UserId_FK,
            DeviceId = e.DeviceId,
            DeviceName = e.DeviceName,
            AppName = e.AppName,
            Version = e.Version,
            DeviceType = e.DeviceType,
            DeviceToken = e.DeviceToken,
            FirstRegisterIpAddress = e.FirstRegisterIpAddress,
            Status = e.Status,
            Remarks = e.Remarks,
            CreatedDate = e.CreatedDate,
            CreatedBy_FK = e.CreatedBy_FK,
            ModifiedDate = e.ModifiedDate,
            ModifiedBy_FK = e.ModifiedBy_FK
        };
}
