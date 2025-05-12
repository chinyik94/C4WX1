using C4WX1.API.Features.MailSettings.Dtos;

namespace C4WX1.API.Features.MailSettings.Mappers;

public class UpdateMailSettingsMapper
    : RequestMapper<UpdateMailSettingsDto, Database.Models.MailSettings>
{
    public override Database.Models.MailSettings UpdateEntity(
        UpdateMailSettingsDto r, 
        Database.Models.MailSettings e)
    {
        e.msgBCC = r.msgBCC;
        e.msgCC = r.msgCC;
        e.msgTo = r.msgTo;
        e.msgSubj = r.msgSubj;
        e.msgBody = r.msgBody;
        e.displayMsgTo = r.displayMsgTo;
        e.displayMsgCC = r.displayMsgCC;
        e.displayMsgBCC = r.displayMsgBCC;
        e.ModifiedBy_FK = r.UserId;
        e.ModifiedDate = DateTime.Now;

        return e;
    }
}
