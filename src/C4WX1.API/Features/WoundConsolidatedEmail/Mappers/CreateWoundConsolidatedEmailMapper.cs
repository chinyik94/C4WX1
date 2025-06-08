using C4WX1.API.Features.WoundConsolidatedEmail.Dtos;

namespace C4WX1.API.Features.WoundConsolidatedEmail.Mappers;

public class CreateWoundConsolidatedEmailMapper
    : RequestMapper<CreateWoundConsolidatedEmailDto, Database.Models.WoundConsolidatedEmail>
{
    public override Database.Models.WoundConsolidatedEmail ToEntity(CreateWoundConsolidatedEmailDto r)
        => new()
        {
            PatientWoundVisitID_FK = r.PatientWoundVisitID_FK,
            MailSettingsID_FK = r.MailSettingsID_FK,
            PDFContent = r.PDFContent,
            CreatedBy_FK = r.UserId,
            CreatedDate = DateTime.Now,
            IsDeleted = false
        };
}
