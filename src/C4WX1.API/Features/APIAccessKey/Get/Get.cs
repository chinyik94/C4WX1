using C4WX1.API.Features.APIAccessKey.Dtos;
using C4WX1.API.Features.APIAccessKey.Mappers;
using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.APIAccessKey.Get
{
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

    public class Get(THCC_C4WDEVContext dbContext)
        : Endpoint<GetAPIAccessKeyDto, APIAccessKeyDto, APIAccessKeyMapper>
    {
        public override void Configure()
        {
            Get("api-access-key/{id}");
            Description(b => b
                .Produces<APIAccessKeyDto>()
                .Produces(404)
                .ProducesProblemFE<InternalErrorResponse>(500));
            Summary(new GetAPIAccessKeySummary());
        }

        public override async Task HandleAsync(GetAPIAccessKeyDto req, CancellationToken ct)
        {
            var dto = await dbContext.APIAccessKey
                .Where(x => x.APIAccessKeyID == req.Id
                    && (string.IsNullOrWhiteSpace(req.AccessKey) || x.AccessKey == req.AccessKey))
                .Select(x => Map.FromEntity(x))
                .FirstOrDefaultAsync(ct);

            if (dto == null)
            {
                await SendNotFoundAsync(ct);
                return;
            }
            await SendAsync(dto, cancellation: ct);
        }
    }
}
