namespace C4WX1.API.Features.WoundConsolidatedEmail.Dtos;

public sealed class GetExistingWoundConsolidatedEmailListDto
{
    [QueryParam]
    public int WoundVisitId { get; set; }

    [QueryParam]
    public int MailSettingsId { get; set; }
}
