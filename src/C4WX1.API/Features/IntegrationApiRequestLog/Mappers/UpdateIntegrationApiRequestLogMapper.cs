using C4WX1.API.Features.IntegrationApiRequestLog.Dtos;

namespace C4WX1.API.Features.IntegrationApiRequestLog.Mappers;

public sealed class UpdateIntegrationApiRequestLogMapper
    : RequestMapper<UpdateIntegrationApiRequestLogDto, Database.Models.IntegrationApiRequestLog>
{
    public override Database.Models.IntegrationApiRequestLog UpdateEntity(
        UpdateIntegrationApiRequestLogDto r, 
        Database.Models.IntegrationApiRequestLog e)
    {
        e.Status = r.Status;

        return e;
    }
}
