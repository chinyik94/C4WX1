using C4WX1.API.WoundConsolidatedEmail.Dtos;

namespace C4WX1.API.WoundConsolidatedEmail.Mappers;

public class UpdateWoundConsolidatedEmailMapper
    : RequestMapper<UpdateWoundConsolidatedEmailDto, Database.Models.WoundConsolidatedEmail>
{
    public override Database.Models.WoundConsolidatedEmail UpdateEntity(
        UpdateWoundConsolidatedEmailDto r, 
        Database.Models.WoundConsolidatedEmail e)
    {
        e.PatientWoundVisitID_FK = r.PatientWoundVisitID_FK;
        e.MailSettingsID_FK = r.MailSettingsID_FK;
        e.PDFContent = r.PDFContent;
        e.ModifiedBy_FK = r.UserId;
        e.ModifiedDate = DateTime.Now;

        return e;
    }
}
