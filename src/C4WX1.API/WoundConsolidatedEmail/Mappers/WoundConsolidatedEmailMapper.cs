using C4WX1.API.WoundConsolidatedEmail.Dtos;

namespace C4WX1.API.WoundConsolidatedEmail.Mappers;

public class WoundConsolidatedEmailMapper
    : ResponseMapper<WoundConsolidatedEmailDto, Database.Models.WoundConsolidatedEmail>
{
    public override WoundConsolidatedEmailDto FromEntity(Database.Models.WoundConsolidatedEmail e)
        => new()
        {
            WoundConsolidatedEmailID = e.WoundConsolidatedEmailID,
            PatientWoundVisitID_FK = e.PatientWoundVisitID_FK,
            MailSettingsID_FK = e.MailSettingsID_FK,
            PDFContent = e.PDFContent,
            IsDeleted = e.IsDeleted,
            CreatedBy_FK = e.CreatedBy_FK,
            CreatedDate = e.CreatedDate,
            ModifiedBy_FK = e.ModifiedBy_FK,
            ModifiedDate = e.ModifiedDate
        };
}
