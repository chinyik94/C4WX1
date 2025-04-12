using FastEndpoints;

namespace C4WX1.API.Features.C4WDeviceToken.Dtos;

public sealed class GetC4WDeviceTokenByOldDeviceTokenDto
{
    public string OldDeviceToken { get; set; } = null!;
}
