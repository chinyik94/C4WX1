using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.WoundConsolidatedEmail.Dtos;

public sealed class UpdateWoundConsolidatedEmailDto : UpdateDto
{
    public int PatientWoundVisitID_FK { get; set; }
    public int MailSettingsID_FK { get; set; }
    public string? PDFContent { get; set; }
}
