using C4WX1.API.Features.VitalSignType.Dtos;

namespace C4WX1.API.Features.VitalSignType.Mappers;

public class CreateVitalSignTypeThresholdMapper
    : RequestMapper<CreateVitalSignTypeThresholdDto, VitalSignTypeThreshold>
{
    public override VitalSignTypeThreshold ToEntity(CreateVitalSignTypeThresholdDto r)
        => new()
        {
            VitalSignTypeID_FK = r.Id,
            ews_min_1 = r.EwsMin1,
            ews_max_1 = r.EwsMax1,
            ews_min_2 = r.EwsMin2,
            ews_max_2 = r.EwsMax2,
            ews_min_3 = r.EwsMin3,
            ews_max_3 = r.EwsMax3,
            ews_min_4 = r.EwsMin4,
            ews_max_4 = r.EwsMax4,
            ews_min_5 = r.EwsMin5,
            ews_max_5 = r.EwsMax5,
            ews_min_6 = r.EwsMin6,
            ews_max_6 = r.EwsMax6,
            ews_min_7 = r.EwsMin7,
            ews_max_7 = r.EwsMax7,
            CreatedBy_FK = r.UserId,
            CreatedDate = DateTime.Now
        };
}
