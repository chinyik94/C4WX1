using C4WX1.API.Features.C4WDeviceToken.Dtos;
using C4WX1.API.Features.C4WDeviceToken.Mappers;

namespace C4WX1.API.Features.C4WDeviceToken.Endpoints;

public class GetC4WDeviceTokenByOldDeviceTokenSummary : EndpointSummary
{
    public GetC4WDeviceTokenByOldDeviceTokenSummary()
    {
        Summary = "Get C4W Device Token by Old Device Token";
        Description = "Get a C4W Device Token by Old Device Token";
        Responses[200] = "C4W Device Token retrieved successfully";
        Responses[404] = "C4W Device Token not found";
    }
}

public class GetByOldDeviceToken(THCC_C4WDEVContext dbContext)
    : Endpoint<GetC4WDeviceTokenByOldDeviceTokenDto, C4WDeviceTokenDto, C4WDeviceTokenMapper>
{
    public override void Configure()
    {
        Get("c4w-device-token/old-device-token/{OldDeviceToken}");
        Description(b => b.Produces(404));
        Summary(new GetC4WDeviceTokenByOldDeviceTokenSummary());
    }

    public override async Task HandleAsync(GetC4WDeviceTokenByOldDeviceTokenDto req, CancellationToken ct)
    {
        var dto = await dbContext.C4WDeviceToken
            .Where(x => !x.IsDeleted && x.OldDeviceToken == req.OldDeviceToken)
            .Select(x => Map.FromEntity(x))
            .FirstOrDefaultAsync(ct);
        if (dto == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        await SendOkAsync(dto, cancellation: ct);
    }
}
