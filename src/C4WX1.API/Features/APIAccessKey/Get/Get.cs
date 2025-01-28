using C4WX1.API.Features.APIAccessKey.Shared;
using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

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
            Summary = $"Get {nameof(APIAccessKey)}";
            Description = $"Get {nameof(APIAccessKey)} by ID or Access Key";
            Responses[200] = $"{nameof(APIAccessKey)} retrieved successfully";
            Responses[404] = $"{nameof(APIAccessKey)} not found";
        }
    }

    public class Get(
        THCC_C4WDEVContext dbContext): Endpoint<GetAccessKeyRequestDto, APIAccessKeyDto>
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

        public override async System.Threading.Tasks.Task HandleAsync(GetAccessKeyRequestDto req, CancellationToken ct)
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

            var dto = new APIAccessKeyDto()
            {
                APIAccessKeyID = entity.APIAccessKeyID,
                TokenCode = entity.TokenCode,
                AccessKey = entity.AccessKey,
                ExpiryDate = entity.ExpiryDate,
                CreatedDate = entity.CreatedDate,
                UpdatedDate = entity.UpdatedDate,
                UserId_FK = entity.UserId_FK
            };
            await SendAsync(dto, cancellation: ct);
        }
    }
}
