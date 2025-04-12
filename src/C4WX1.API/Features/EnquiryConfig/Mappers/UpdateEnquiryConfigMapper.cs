using C4WX1.API.Features.EnquiryConfig.Dtos;
using FastEndpoints;

namespace C4WX1.API.Features.EnquiryConfig.Mappers;

public class UpdateEnquiryConfigMapper
    : RequestMapper<UpdateEnquiryConfigDto, Database.Models.EnquiryConfig>
{
    public override Database.Models.EnquiryConfig UpdateEntity(
        UpdateEnquiryConfigDto r, 
        Database.Models.EnquiryConfig e)
    {
        e.SCMID_FK = r.SCMID_FK;
        e.EmailContent = r.EmailContent;
        e.EscalatingPersonID_FK = r.EscalatingPersonID_FK;
        e.EscalationPeriod = r.EscalationPeriod;
        e.EscalationEmail = r.EscalationEmail;
        e.EmailtoCMContent = r.EmailtoCMContent;
        e.ModifiedBy_FK = r.UserId;
        e.ModifiedDate = DateTime.Now;

        return e;
    }
}
