using C4WX1.API.Features.IntegrationApiRequestLog.Dtos;
using C4WX1.API.Features.IntegrationApiRequestLog.Mappers;
using C4WX1.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace C4WX1.API.Features.IntegrationApiRequestLog.Endpoints;

public class UpdateIntegrationApiRequestLogSummary : EndpointSummary
{
    public UpdateIntegrationApiRequestLogSummary()
    {
        Summary = "Update IntegrationApiRequestLog";
        Description = "Update an existing IntegrationApiRequestLog by its ID";
        ExampleRequest = new UpdateIntegrationApiRequestLogDto
        {
            Id = 1,
            Status = "example-Status",
            UserId = 1,
        };
        Responses[204] = "IntegrationApiRequestLog updated successfully";
        Responses[404] = "IntegrationApiRequestLog not found";
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
