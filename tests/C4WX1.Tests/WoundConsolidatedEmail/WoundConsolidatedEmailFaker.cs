using C4WX1.API.Features.WoundConsolidatedEmail.Dtos;

namespace C4WX1.Tests.WoundConsolidatedEmail;

public class WoundConsolidatedEmailFaker
{
    public static CreateWoundConsolidatedEmailDto CreateDto(int mailSettingsId)
        => new()
        {
            PatientWoundVisitID_FK = 1,
            MailSettingsID_FK = mailSettingsId,
            PDFContent = "control-PDFContent",
            UserId = 1
        };

    public static CreateWoundConsolidatedEmailDto CreateDummy
        => new Faker<CreateWoundConsolidatedEmailDto>()
        .RuleFor(x => x.PatientWoundVisitID_FK, f => 1)
        .RuleFor(x => x.MailSettingsID_FK, f => 1)
        .RuleFor(x => x.PDFContent, f => C4WX1Faker.ShortString)
        .RuleFor(x => x.UserId, f => C4WX1Faker.Id)
        .Generate();

    public static UpdateWoundConsolidatedEmailDto UpdateDto(int mailSettingsId, int? id = null)
        => new()
        {
            Id = id ?? C4WX1Faker.Id,
            PatientWoundVisitID_FK = 1,
            MailSettingsID_FK = mailSettingsId,
            PDFContent = "updated-control-PDFContent",
            UserId = 1
        };
}
