using C4WX1.API.Features.APIAccessKey.Dtos;
using C4WX1.API.Features.APIAccessKey.Mappers;
using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.APIAccessKey.Get
{
    public class GetAccessKeyRequestDto
    {
        [QueryParam]
        public int? ID { get; set; }

        [QueryParam]
        public string? AccessKey { get; set; } = string.Empty;
    }

    public class GetAPIAccessKeySummary : EndpointSummary
    {
        public GetAPIAccessKeySummary()
        {
            Summary = "Get APIAccessKey";
            Description = "Get APIAccessKey by its ID or Access Key";
            Responses[200] = "APIAccessKey retrieved successfully";
            Responses[404] = "APIAccessKey not found";
        }
    }

    public class Get(
        THCC_C4WDEVContext dbContext): Endpoint<GetAccessKeyRequestDto, APIAccessKeyDto, APIAccessKeyMapper>
    {
        public override void Configure()
        {
            Get("api-access-key");
            Description(b => b
                .Produces<APIAccessKeyDto>()
                .Produces(404)
                .ProducesProblemFE<InternalErrorResponse>(500));
            Summary(new GetAPIAccessKeySummary());
        }

        public override async Task HandleAsync(GetAccessKeyRequestDto req, CancellationToken ct)
        {
            var query = dbContext.APIAccessKey.AsQueryable();
            if (req.ID != null)
            { 
                query = query.Where(a => a.APIAccessKeyID == req.ID);
            }
            if (!string.IsNullOrWhiteSpace(req.AccessKey))
            {
                query = query.Where(a => a.AccessKey == req.AccessKey);
            }

            var entity = await query.FirstOrDefaultAsync(ct);
            if (entity == null)
            {
                await SendNotFoundAsync(ct);
                return;
            }

            var dto = Map.FromEntity(entity);
            await SendAsync(dto, cancellation: ct);
        }
    }
}
