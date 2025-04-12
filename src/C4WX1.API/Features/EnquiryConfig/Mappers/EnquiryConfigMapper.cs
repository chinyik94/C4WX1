using C4WX1.API.Features.EnquiryConfig.Dtos;
using FastEndpoints;

namespace C4WX1.API.Features.EnquiryConfig.Mappers;

public class EnquiryConfigMapper
    : ResponseMapper<EnquiryConfigDto, Database.Models.EnquiryConfig>
{
    public override EnquiryConfigDto FromEntity(Database.Models.EnquiryConfig e) => new()
    {
        EnquiryConfigID = e.EnquiryConfigID,
        SCMID_FK = e.SCMID_FK,
        EmailContent = e.EmailContent,
        EscalatingPersonID_FK = e.EscalatingPersonID_FK,
        EscalationPeriod = e.EscalationPeriod,
        EscalationEmail = e.EscalationEmail,
        EmailtoCMContent = e.EmailtoCMContent,
        CreatedDate = e.CreatedDate,
        CreatedBy_FK = e.CreatedBy_FK,
        ModifiedDate = e.ModifiedDate,
        ModifiedBy_FK = e.ModifiedBy_FK
    };
}
