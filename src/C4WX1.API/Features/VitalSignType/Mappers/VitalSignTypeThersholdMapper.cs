using C4WX1.API.Features.VitalSignType.Dtos;

namespace C4WX1.API.Features.VitalSignType.Mappers;

public class VitalSignTypeThersholdMapper
    : ResponseMapper<VitalSignTypeThresholdDto, VitalSignTypeThreshold>
{
    public override VitalSignTypeThresholdDto FromEntity(VitalSignTypeThreshold e)
        => new()
        {
            VitalSignTypeID_FK = e.VitalSignTypeID_FK,
            EwsMin1 = e.ews_min_1,
            EwsMax1 = e.ews_max_1,
            EwsMin2 = e.ews_min_2,
            EwsMax2 = e.ews_max_2,
            EwsMin3 = e.ews_min_3,
            EwsMax3 = e.ews_max_3,
            EwsMin4 = e.ews_min_4,
            EwsMax4 = e.ews_max_4,
            EwsMin5 = e.ews_min_5,
            EwsMax5 = e.ews_max_5,
            EwsMin6 = e.ews_min_6,
            EwsMax6 = e.ews_max_6,
            EwsMin7 = e.ews_min_7,
            EwsMax7 = e.ews_max_7,
        };
}
