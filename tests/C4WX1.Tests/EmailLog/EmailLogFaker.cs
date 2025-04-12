using C4WX1.API.Features.EmailLog.Dtos;
using C4WX1.Tests.Shared;

namespace C4WX1.Tests.EmailLog;

public class EmailLogFaker : C4WX1Faker
{
    public static CreateEmailLogDto CreateDummy => new Faker<CreateEmailLogDto>()
        .RuleFor(x => x.msgBCC, f => f.Random.AlphaNumeric(10))
        .RuleFor(x => x.msgCC, f => f.Random.AlphaNumeric(10))
        .RuleFor(x => x.msgTo, f => f.Random.AlphaNumeric(10))
        .RuleFor(x => x.msgSubj, f => f.Random.AlphaNumeric(10))
        .RuleFor(x => x.msgBody, f => f.Random.AlphaNumeric(10))
        .RuleFor(x => x.msgFromName, f => f.Random.AlphaNumeric(10))
        .RuleFor(x => x.msgFrom, f => f.Random.AlphaNumeric(10))
        .RuleFor(x => x.isHtml, f => f.Random.Bool())
        .RuleFor(x => x.attachmentName, f => f.Random.AlphaNumeric(10))
        .RuleFor(x => x.isSent, f => f.Random.Bool())
        .RuleFor(x => x.smtpLogin, f => f.Random.AlphaNumeric(10))
        .RuleFor(x => x.smtpPassword, f => f.Random.AlphaNumeric(10))
        .RuleFor(x => x.smtpPort, f => f.Random.AlphaNumeric(10))
        .RuleFor(x => x.smtpServerAddress, f => f.Random.AlphaNumeric(10))
        .Generate();
}
