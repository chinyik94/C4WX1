namespace C4WX1.API.Features.IntegrationApiRequestLog.Dtos;

public sealed class IntegrationApiRequestLogDto
{
    public int IntegrationApiRequestLogID { get; set; }
    public string IntegrationSource { get; set; } = null!;
    public string? FacilityId { get; set; }
    public string ResidentId { get; set; } = null!;
    public string Url { get; set; } = null!;
    public string Content { get; set; } = null!;
    public string Status { get; set; } = null!;
    public int? CreatedByID_FK { get; set; }
    public DateTime? Timestamp { get; set; }
}
