using C4WX1.API.Features.VitalSignType.Dtos;

namespace C4WX1.API.Features.VitalSignType.Mappers;

public class UpdateVitalSignTypeThresholdMapper
    : RequestMapper<UpdateVitalSignTypeThresholdDto, VitalSignTypeThreshold>
{
    public override VitalSignTypeThreshold UpdateEntity(
        UpdateVitalSignTypeThresholdDto r, 
        VitalSignTypeThreshold e)
    {
        e.ews_min_1 = r.EwsMin1;
        e.ews_max_1 = r.EwsMax1;
        e.ews_min_2 = r.EwsMin2;
        e.ews_max_2 = r.EwsMax2;
        e.ews_min_3 = r.EwsMin3;
        e.ews_max_3 = r.EwsMax3;
        e.ews_min_4 = r.EwsMin4;
        e.ews_max_4 = r.EwsMax4;
        e.ews_min_5 = r.EwsMin5;
        e.ews_max_5 = r.EwsMax5;
        e.ews_min_6 = r.EwsMin6;
        e.ews_max_6 = r.EwsMax6;
        e.ews_min_7 = r.EwsMin7;
        e.ews_max_7 = r.EwsMax7;
        e.ModifiedBy_FK = r.UserId;
        e.ModifiedDate = DateTime.Now;

        return e;
    }
}
