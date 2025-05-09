using C4WX1.API.Features.C4WDeviceToken.Dtos;
using C4WX1.API.Features.C4WDeviceToken.Mappers;

namespace C4WX1.API.Features.C4WDeviceToken.Endpoints;

public class CreateC4WDeviceTokenSummary 
    : C4WX1CreateSummary<Database.Models.C4WDeviceToken>
{
    public CreateC4WDeviceTokenSummary() : base()
    {
        ExampleRequest = new CreateC4WDeviceTokenDto
        {
            OldDeviceToken = "Old Token",
            NewDeviceToken = "New Token",
            ClientEnvironment = "test env",
            Device = "Iphone",
            UserId = 1
        };
    }
}

public class Create(THCC_C4WDEVContext dbContext)
    : Endpoint<CreateC4WDeviceTokenDto, int, CreateC4WDeviceTokenMapper>
{
    public override void Configure()
    {
        Post("c4w-device-token");
        Summary(new CreateC4WDeviceTokenSummary());
    }

    public override async Task HandleAsync(CreateC4WDeviceTokenDto req, CancellationToken ct)
    {
        var entity = Map.ToEntity(req);
        dbContext.C4WDeviceToken.Add(entity);
        await dbContext.SaveChangesAsync(ct);
        await SendOkAsync(entity.C4WDeviceTokenId, cancellation: ct);
    }
}
