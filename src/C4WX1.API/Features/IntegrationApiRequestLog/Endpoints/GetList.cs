using C4WX1.API.Features.IntegrationApiRequestLog.Dtos;
using C4WX1.API.Features.IntegrationApiRequestLog.Mappers;

namespace C4WX1.API.Features.IntegrationApiRequestLog.Endpoints;

public class GetIntegrationApiRequestLogListSummary 
    : C4WX1GetListSummary<Database.Models.IntegrationApiRequestLog>
{
    public GetIntegrationApiRequestLogListSummary() { }
}

public class GetList(THCC_C4WDEVContext dbContext)
    : Endpoint<GetIntegrationApiRequestLogListDto, IEnumerable<IntegrationApiRequestLogDto>, IntegrationApiRequestLogMapper>
{
    public override void Configure()
    {
        Get("integration-api-request-log");
        Summary(new GetIntegrationApiRequestLogListSummary());
    }

    public override async Task HandleAsync(GetIntegrationApiRequestLogListDto req, CancellationToken ct)
    {
        var query = dbContext.IntegrationApiRequestLog
            .AsQueryable();
        if (!string.IsNullOrWhiteSpace(req.Status))
        {
            query = query.Where(x => x.Status == req.Status);
        }
        if (req.StartDate != null)
        {
            query = query.Where(x => x.Timestamp >= req.StartDate);
        }
        if (req.EndDate != null)
        {
            query = query.Where(x => x.Timestamp <= req.EndDate);
        }
        var dtos = await query
            .Select(x => Map.FromEntity(x))
            .ToListAsync(ct);
        await SendOkAsync(dtos, cancellation: ct);
    }
}
