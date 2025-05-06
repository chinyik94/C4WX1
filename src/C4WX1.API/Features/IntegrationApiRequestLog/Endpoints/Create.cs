using C4WX1.API.Features.IntegrationApiRequestLog.Dtos;
using C4WX1.API.Features.IntegrationApiRequestLog.Mappers;
using C4WX1.Database.Models;

namespace C4WX1.API.Features.IntegrationApiRequestLog.Endpoints;

public class CreateIntegrationApiRequestLogSummary : EndpointSummary
{
    public CreateIntegrationApiRequestLogSummary()
    {
        Summary = "Create IntegrationApiRequestLog";
        Description = "Create a new IntegrationApiRequestLog";
        ExampleRequest = new CreateIntegrationApiRequestLogDto
        {
            IntegrationSource = "example-IntegrationSource",
            FacilityId = "1",
            ResidentId = "1",
            Url = "example-Url",
            Content = "example-Content",
            Status = "example-Status",
            UserId = 1
        };
        Responses[200] = "IntegrationApiRequestLog created successfully";
    }
}

public class Create(THCC_C4WDEVContext dbContext)
    : Endpoint<CreateIntegrationApiRequestLogDto, int, CreateIntegrationApiRequestLogMapper>
{
    public override void Configure()
    {
        Post("integration-api-request-log");
        Summary(new CreateIntegrationApiRequestLogSummary());
    }

    public override async Task HandleAsync(CreateIntegrationApiRequestLogDto req, CancellationToken ct)
    {
        var entity = Map.ToEntity(req);
        await dbContext.IntegrationApiRequestLog.AddAsync(entity, ct);
        await dbContext.SaveChangesAsync(ct);
        await SendOkAsync(entity.IntegrationApiRequestLogID, cancellation: ct);
    }
}
