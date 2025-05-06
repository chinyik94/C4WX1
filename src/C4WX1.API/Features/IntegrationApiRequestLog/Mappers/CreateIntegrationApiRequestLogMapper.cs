using C4WX1.API.Features.IntegrationApiRequestLog.Dtos;

namespace C4WX1.API.Features.IntegrationApiRequestLog.Mappers;

public class CreateIntegrationApiRequestLogMapper 
    : RequestMapper<CreateIntegrationApiRequestLogDto, Database.Models.IntegrationApiRequestLog>
{
    public override Database.Models.IntegrationApiRequestLog ToEntity(CreateIntegrationApiRequestLogDto r)
        => new()
        {
            IntegrationSource = r.IntegrationSource,
            FacilityId = r.FacilityId,
            ResidentId = r.ResidentId,
            Url = r.Url,
            Content = r.Content,
            Status = r.Status,
            CreatedByID_FK = r.UserId,
            Timestamp = DateTime.Now
        };
}
