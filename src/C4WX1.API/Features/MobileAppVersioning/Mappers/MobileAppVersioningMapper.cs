using C4WX1.API.Features.MobileAppVersioning.Dtos;

namespace C4WX1.API.Features.MobileAppVersioning.Mappers;

public class MobileAppVersioningMapper
    : ResponseMapper<MobileAppVersioningDto, Database.Models.MobileAppVersioning>
{
    public override MobileAppVersioningDto FromEntity(Database.Models.MobileAppVersioning e)
        => new()
        {
            MobileVersionId = e.MobileVersionId,
            AppName = e.AppName,
            Version = e.Version,
            DeviceType = e.DeviceType,
            Status = e.Status,
            CreatedDate = e.CreatedDate,
            CreatedBy_FK = e.CreatedBy_FK,
            ModifiedDate = e.ModifiedDate,
            ModifiedBy_FK = e.ModifiedBy_FK,
        };
}
