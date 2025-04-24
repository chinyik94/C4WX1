using C4WX1.API.Features.EmailLog.Dtos;
using FastEndpoints;

namespace C4WX1.API.Features.EmailLog.Mappers;

public class CreateEmailLogMapper
    : RequestMapper<CreateEmailLogDto, Database.Models.EmailLog>
{
    public override Database.Models.EmailLog ToEntity(CreateEmailLogDto r) => new()
    {
        msgBCC = r.msgBCC,
        msgCC = r.msgCC,
        msgTo = r.msgTo,
        msgSubj = r.msgSubj,
        msgBody = r.msgBody,
        msgFromName = r.msgFromName,
        msgFrom = r.msgFrom,
        isHtml = r.isHtml,
        attachmentName = r.attachmentName,
        CreatedDate = DateTime.Now,
        isSent = r.isSent,
        smtpLogin = r.smtpLogin,
        smtpPassword = r.smtpPassword,
        smtpPort = r.smtpPort,
        smtpServerAddress = r.smtpServerAddress,
    };
}
