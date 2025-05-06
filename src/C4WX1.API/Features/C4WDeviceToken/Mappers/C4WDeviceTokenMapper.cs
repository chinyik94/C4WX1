using C4WX1.API.Features.C4WDeviceToken.Dtos;

namespace C4WX1.API.Features.C4WDeviceToken.Mappers;

public class C4WDeviceTokenMapper
    : ResponseMapper<C4WDeviceTokenDto, Database.Models.C4WDeviceToken>
{
    public override C4WDeviceTokenDto FromEntity(Database.Models.C4WDeviceToken e) => new()
    {
        C4WDeviceTokenId = e.C4WDeviceTokenId,
        OldDeviceToken = e.OldDeviceToken,
        NewDeviceToken = e.NewDeviceToken,
        Device = e.Device,
        ClientEnvironment = e.ClientEnvironment,
    };
}
