﻿using C4WX1.API.Features.EmailLog.Dtos;

namespace C4WX1.Tests.EmailLog;

public class EmailLogFaker
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

    public static CreateEmailLogDto CreateDto => new()
    {
        msgBCC = "control-msgBcc",
        msgCC = "control-msgcc",
        msgTo = "control-msgTo",
        msgSubj = "control-msgSub",
        msgBody = "control-msgBody",
        msgFromName = "control-msgFromName",
        msgFrom = "control-msgFrom",
        isHtml = false,
        attachmentName = "control-attachmentName",
        isSent = false,
        smtpLogin = "control-smtpLogin",
        smtpPassword = "control-smtpPassword",
        smtpPort = "control-smtpPort",
        smtpServerAddress = "control-smtpServerAddress"
    };
}
