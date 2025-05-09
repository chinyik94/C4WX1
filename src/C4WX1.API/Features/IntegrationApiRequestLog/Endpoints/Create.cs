using C4WX1.API.Features.IntegrationApiRequestLog.Dtos;
using C4WX1.API.Features.IntegrationApiRequestLog.Mappers;

namespace C4WX1.API.Features.IntegrationApiRequestLog.Endpoints;

public class CreateIntegrationApiRequestLogSummary 
    : C4WX1CreateSummary<Database.Models.IntegrationApiRequestLog>
{
    public CreateIntegrationApiRequestLogSummary() : base()
    {
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
