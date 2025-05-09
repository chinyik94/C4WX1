using C4WX1.API.Features.EnquiryConfig.Dtos;

namespace C4WX1.Tests.EnquiryConfig;

public class EnquiryConfigFaker
{
    public static CreateEnquiryConfigDto CreateDto => new()
    {
        SCMID_FK = 1,
        EmailContent = "control-EmailContent",
        EscalatingPersonID_FK = 1,
        EscalationPeriod = 1,
        EscalationEmail = "control-EscalationEmail",
        EmailtoCMContent = "control-EmailtoCMContent",
        SCMList = [1, 2, 3],
        EscPersonList = [1, 2, 3]
    };

    public static UpdateEnquiryConfigDto UpdateDto(int? id = null) => new()
    {
        Id = id ?? C4WX1Faker.Id,
        SCMID_FK = 2,
        EmailContent = "updated-control-EmailContent",
        EscalatingPersonID_FK = 2,
        EscalationPeriod = 2,
        EscalationEmail = "updated-control-EscalationEmail",
        EmailtoCMContent = "updated-control-EmailtoCMContent",
        SCMList = [4, 5, 6],
        EscPersonList = [4, 5, 6]
    };
}
