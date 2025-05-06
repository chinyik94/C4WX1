using C4WX1.API.Features.EmailLog.Dtos;

namespace C4WX1.API.Features.EmailLog.Mappers;

public class EmailLogMapper
    : ResponseMapper<EmailLogDto, Database.Models.EmailLog>
{
    public override EmailLogDto FromEntity(Database.Models.EmailLog e) => new()
    {
        EmailLogId = e.EmailLogId,
        description = e.description,
        msgBCC = e.msgBCC,
        msgCC = e.msgCC,
        msgTo = e.msgTo,
        msgSubj = e.msgSubj,
        msgBody = e.msgBody,
        msgFromName = e.msgFromName,
        msgFrom = e.msgFrom,
        isHtml = e.isHtml,
        attachmentName = e.attachmentName,
        isSent = e.isSent,
        CreatedDate = e.CreatedDate,
        smtpLogin = e.smtpLogin,
        smtpPassword = e.smtpPassword,
        smtpPort = e.smtpPort,
        smtpServerAddress = e.smtpServerAddress
    };
}
