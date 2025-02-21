using C4WX1.API.Features.APIAccessKey.Dtos;
using C4WX1.API.Features.APIAccessKey.Mappers;
using C4WX1.API.Features.Generator;
using C4WX1.API.Features.Security;
using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.APIAccessKey.Create
{
    public class CreateAPIAccessKeySummary : EndpointSummary
    {
        public CreateAPIAccessKeySummary()
        {
            Summary = "Create APIAccessKey";
            Description = "Create a new APIAccessKey";
            Responses[200] = "APIAccessKey created successfully";
            Responses[404] = "APIAccessKey not found";
        }
    }

    public class Create(
        THCC_C4WDEVContext dbContext,
        IPasswordGenerator passwordGenerator,
        ISecurityService securityService)
        : Endpoint<CreateAPIAccessKeyDto, APIAccessKeyDto, APIAccessKeyMapper>
    {
        public override void Configure()
        {
            Post("api-access-key");
            AllowAnonymous();
            Description(b => b
                .Accepts<CreateAPIAccessKeyDto>()
                .Produces<APIAccessKeyDto>()
                .Produces(404)
                .ProducesProblemFE<InternalErrorResponse>(500));
            Summary(new CreateAPIAccessKeySummary());
        }

        public override async Task HandleAsync(CreateAPIAccessKeyDto req, CancellationToken ct)
        {
            var type = await dbContext.Types
                .FirstOrDefaultAsync(t => t.code == req.Code, ct);
            if (type == null)
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
                TokenCode = type.code,
                ExpiryDate = DateTime.Now.AddDays(1),
                UserId_FK = req.UserId
            };
            dbContext.APIAccessKey.Add(entity);
            await dbContext.SaveChangesAsync(ct);
            var dto = Map.FromEntity(entity);
            await SendAsync(dto, cancellation: ct);
        }
    }
}
