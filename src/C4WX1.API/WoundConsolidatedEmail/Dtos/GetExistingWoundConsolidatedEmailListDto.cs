namespace C4WX1.API.WoundConsolidatedEmail.Dtos;

public sealed class GetExistingWoundConsolidatedEmailListDto
{
    [QueryParam]
    public int WoundVisitId { get; set; }

    [QueryParam]
    public int MailSettingsId { get; set; }
}
