using C4WX1.API.Features.IntegrationApiRequestLog.Dtos;
using C4WX1.API.Features.IntegrationApiRequestLog.Mappers;

namespace C4WX1.API.Features.IntegrationApiRequestLog.Endpoints;

public class UpdateIntegrationApiRequestLogSummary 
    : C4WX1UpdateSummary<Database.Models.IntegrationApiRequestLog>
{
    public UpdateIntegrationApiRequestLogSummary() : base()
    {
        ExampleRequest = new UpdateIntegrationApiRequestLogDto
        {
            Id = 1,
            Status = "example-Status",
            UserId = 1,
        };
    }
}

public class Update(THCC_C4WDEVContext dbContext)
    : EndpointWithMapper<UpdateIntegrationApiRequestLogDto, UpdateIntegrationApiRequestLogMapper>
{
    public override void Configure()
    {
        Put("integration-api-request-log/{id}");
        Summary(new UpdateIntegrationApiRequestLogSummary());
    }

    public override async Task HandleAsync(UpdateIntegrationApiRequestLogDto req, CancellationToken ct)
    {
        var entity = await dbContext.IntegrationApiRequestLog
            .Where(x => x.IntegrationApiRequestLogID == req.Id)
            .FirstOrDefaultAsync(ct);
        if (entity == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        entity = Map.UpdateEntity(req, entity);
        await dbContext.SaveChangesAsync(ct);
        await SendNoContentAsync(ct);
    }
}
