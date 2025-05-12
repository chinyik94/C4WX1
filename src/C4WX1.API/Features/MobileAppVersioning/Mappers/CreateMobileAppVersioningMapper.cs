using C4WX1.API.Features.MobileAppVersioning.Dtos;
using C4WX1.API.Features.Shared.Constants;

namespace C4WX1.API.Features.MobileAppVersioning.Mappers;

public class CreateMobileAppVersioningMapper
    : RequestMapper<CreateMobileAppVersioningDto, Database.Models.MobileAppVersioning>
{
    public override Database.Models.MobileAppVersioning ToEntity(CreateMobileAppVersioningDto r)
        => new()
        {
            AppName = r.AppName,
            DeviceType = r.DeviceType,
            Version = r.Version,
            Status = Statuses.Pending,
            CreatedBy_FK = r.UserId,
            CreatedDate = DateTime.Now
        };
}
