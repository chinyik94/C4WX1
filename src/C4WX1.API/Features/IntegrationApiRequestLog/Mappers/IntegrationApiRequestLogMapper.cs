using C4WX1.API.Features.IntegrationApiRequestLog.Dtos;

namespace C4WX1.API.Features.IntegrationApiRequestLog.Mappers;

public sealed class IntegrationApiRequestLogMapper
    : ResponseMapper<IntegrationApiRequestLogDto, Database.Models.IntegrationApiRequestLog>
{
    public override IntegrationApiRequestLogDto FromEntity(Database.Models.IntegrationApiRequestLog e)
        => new()
        {
            IntegrationApiRequestLogID = e.IntegrationApiRequestLogID,
            IntegrationSource = e.IntegrationSource,
            FacilityId = e.FacilityId,
            ResidentId = e.ResidentId,
            Url = e.Url,
            Content = e.Content,
            Status = e.Status,
            CreatedByID_FK = e.CreatedByID_FK,
            Timestamp = e.Timestamp
        };
}
