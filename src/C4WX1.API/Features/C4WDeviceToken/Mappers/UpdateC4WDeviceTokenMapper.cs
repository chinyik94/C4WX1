using C4WX1.API.Features.C4WDeviceToken.Dtos;

namespace C4WX1.API.Features.C4WDeviceToken.Mappers;

public class UpdateC4WDeviceTokenMapper 
    : RequestMapper<UpdateC4WDeviceTokenDto, Database.Models.C4WDeviceToken>
{
    public override Database.Models.C4WDeviceToken UpdateEntity(
        UpdateC4WDeviceTokenDto r, 
        Database.Models.C4WDeviceToken e)
    {
        e.OldDeviceToken = r.OldDeviceToken;
        e.NewDeviceToken = r.NewDeviceToken;
        e.Device = r.Device;
        e.ClientEnvironment = r.ClientEnvironment;
        e.ModifiedBy_FK = r.UserId;
        e.ModifiedDate = DateTime.Now;

        return e;
    }
}
