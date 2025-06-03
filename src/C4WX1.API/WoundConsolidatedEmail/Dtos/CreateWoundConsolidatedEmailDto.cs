using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.WoundConsolidatedEmail.Dtos;

public sealed class CreateWoundConsolidatedEmailDto : CreateDto
{
    public int PatientWoundVisitID_FK { get; set; }
    public int MailSettingsID_FK { get; set; }
    public string? PDFContent { get; set; }
}
