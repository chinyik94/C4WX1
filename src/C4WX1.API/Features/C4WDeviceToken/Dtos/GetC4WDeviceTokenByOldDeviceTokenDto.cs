using FastEndpoints;

namespace C4WX1.API.Features.C4WDeviceToken.Dtos
{
    public class GetC4WDeviceTokenByOldDeviceTokenDto
    {
        [QueryParam]
        public string OldDeviceToken { get; set; }
    }
}
