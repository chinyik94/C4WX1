using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.IntegrationApiRequestLog.Dtos;

public sealed class GetIntegrationApiRequestLogListDto
{
    public string? Status { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}
