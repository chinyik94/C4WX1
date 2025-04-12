using C4WX1.API.Features.APIAccessKey.Dtos;
using C4WX1.API.Features.APIAccessKey.Mappers;
using C4WX1.API.Features.Security;
using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.APIAccessKey.Get;

public class GetAPIAccessKeyByAccessKeySummary : EndpointSummary
{
    public GetAPIAccessKeyByAccessKeySummary()
    {
        Summary = "Get APIAccessKey";
        Description = "Get APIAccessKey by its Access Key";
        Responses[200] = "APIAccessKey retrieved successfully";
        Responses[404] = "APIAccessKey not found";
    }
}

public class GetByAccessKey(
    THCC_C4WDEVContext dbContext,
    ISecurityService securityService)
    : Endpoint<GetAPIAccessKeyByAccessKeyDto, APIAccessKeyDto, APIAccessKeyMapper>
{
    public override void Configure()
    {
        Get("api-access-key/access-key/{accessKey}");
        Description(b => b.Produces(404));
        Summary(new GetAPIAccessKeyByAccessKeySummary());
    }

    public override async Task HandleAsync(
        GetAPIAccessKeyByAccessKeyDto req, 
        CancellationToken ct)
    {
        var accessKey = securityService.Encrypt(req.AccessKey);
        var dto = await dbContext.APIAccessKey
            .Where(x => x.AccessKey == accessKey)
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
