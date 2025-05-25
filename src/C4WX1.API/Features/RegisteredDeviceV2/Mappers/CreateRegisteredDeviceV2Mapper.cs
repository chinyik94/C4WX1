using C4WX1.API.Features.RegisteredDeviceV2.Dtos;
using C4WX1.API.Features.Shared.Constants;

namespace C4WX1.API.Features.RegisteredDeviceV2.Mappers;

public class CreateRegisteredDeviceV2Mapper
    : RequestMapper<CreateRegisteredDeviceV2Dto, Database.Models.RegisteredDeviceV2>
{
    public override Database.Models.RegisteredDeviceV2 ToEntity(CreateRegisteredDeviceV2Dto r)
        => new()
        {
            UserId_FK = r.UserId,
            DeviceId = r.DeviceId,
            DeviceName = r.DeviceName,
            DeviceType = r.DeviceType,
            DeviceToken = r.DeviceToken,
            FirstRegisterIpAddress = r.FirstRegisterIpAddress,
            Remarks = r.Remarks,
            AppName = r.AppName,
            Version = r.Version,
            Status = Statuses.Pending,
            CreatedBy_FK = r.UserId,
            CreatedDate = DateTime.Now,
            IsDeleted = false
        };
}
