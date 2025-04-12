using C4WX1.API.Features.EnquiryConfig.Dtos;
using FastEndpoints;

namespace C4WX1.API.Features.EnquiryConfig.Mappers;

public class CreateEnquiryConfigMapper
    : RequestMapper<CreateEnquiryConfigDto, Database.Models.EnquiryConfig>
{
    public override Database.Models.EnquiryConfig ToEntity(CreateEnquiryConfigDto r) => new()
    {
        SCMID_FK = r.SCMID_FK,
        EmailContent = r.EmailContent,
        EscalatingPersonID_FK = r.EscalatingPersonID_FK,
        EscalationPeriod = r.EscalationPeriod,
        EscalationEmail = r.EscalationEmail,
        EmailtoCMContent = r.EmailtoCMContent,
        CreatedDate = DateTime.Now,
        CreatedBy_FK = r.UserId,
        IsDeleted = false
    };
}
