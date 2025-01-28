using C4WX1.API.Features.APIAccessKey.Shared;
using C4WX1.API.Features.Generator;
using C4WX1.API.Features.Security;
using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace C4WX1.API.Features.APIAccessKey.Create
{
    public class CreateAPIAccessKeyRequestDto
    {
        public string Code { get; set; } = string.Empty;
        public int UserId { get; set; }
    }

    public class CreateAPIAccessKeySummary : EndpointSummary
    {
        public CreateAPIAccessKeySummary()
        {
            Summary = $"Create {nameof(APIAccessKey)}";
            Description = $"Create a new {nameof(APIAccessKey)}";
            Responses[200] = $"{nameof(APIAccessKey)} created successfully";
            Responses[404] = $"{nameof(APIAccessKey)} not found";
        }
    }

    public class Create(
        THCC_C4WDEVContext dbContext,
        IPasswordGenerator passwordGenerator,
        ISecurityService securityService): Endpoint<CreateAPIAccessKeyRequestDto, APIAccessKeyDto>
    {
        public override void Configure()
        {
            Post("api-access-key");
            AllowAnonymous();
            Description(b => b
                .Accepts<CreateAPIAccessKeyRequestDto>("application/json")
                .Produces<APIAccessKeyDto>()
                .Produces(404)
                .ProducesProblemFE<InternalErrorResponse>(500));
            Summary(new CreateAPIAccessKeySummary());
        }

        public override async System.Threading.Tasks.Task HandleAsync(CreateAPIAccessKeyRequestDto req, CancellationToken ct)
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
            var dto = new APIAccessKeyDto
            {
                APIAccessKeyID = entity.APIAccessKeyID,
                AccessKey = entity.AccessKey,
                CreatedDate = entity.CreatedDate,
                TokenCode = entity.TokenCode,
                ExpiryDate = entity.ExpiryDate,
                UserId_FK = entity.UserId_FK
            };
            await SendAsync(dto, cancellation: ct);
        }
    }
}
