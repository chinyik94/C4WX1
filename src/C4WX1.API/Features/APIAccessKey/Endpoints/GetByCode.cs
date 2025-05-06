using C4WX1.API.Features.APIAccessKey.Dtos;
using C4WX1.API.Features.APIAccessKey.Mappers;
using C4WX1.API.Features.Generator;
using C4WX1.API.Features.Security;
using C4WX1.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace C4WX1.API.Features.APIAccessKey.Endpoints;

public class GetAPIAccessKeyByCodeSummary : EndpointSummary
{
    public GetAPIAccessKeyByCodeSummary()
    {
        Summary = "Get APIAccessKey";
        Description = "Get APIAccessKey by Type Code";
        Responses[200] = "APIAccessKey retrieved successfully";
        Responses[404] = "APIAccessKey not found";
    }
}

public class GetByCode(
    THCC_C4WDEVContext dbContext,
    IPasswordGenerator passwordGenerator,
    ISecurityService securityService)
    : Endpoint<GetAPIAccessKeyByCodeDto, APIAccessKeyDto, APIAccessKeyMapper>
{
    public override void Configure()
    {
        Get("api-access-key/code/{code}");
        Description(b => b.Produces(404));
        Summary(new GetAPIAccessKeyByCodeSummary());
    }

    public override async Task HandleAsync(GetAPIAccessKeyByCodeDto req, CancellationToken ct)
    {
        var typeCode = await dbContext.Types
            .Where(x => x.code == req.Code)
            .Select(x => x.code)
            .FirstOrDefaultAsync(ct);
        if (string.IsNullOrWhiteSpace(typeCode))
        {
            await SendNotFoundAsync(ct);
            return;
        }

        var password = await passwordGenerator.GenerateAsync();
        var encryptedPassword = securityService.Encrypt(password);
        var entity = new Database.Models.APIAccessKey
        {
            AccessKey = encryptedPassword,
            CreatedDate = DateTime.Now,
            TokenCode = req.Code,
            ExpiryDate = DateTime.Now.AddDays(1),
            UserId_FK = req.UserId
        };
        dbContext.APIAccessKey.Add(entity);
        await dbContext.SaveChangesAsync(ct);
        var dto = Map.FromEntity(entity);
        await SendAsync(dto, cancellation: ct);
    }
}
