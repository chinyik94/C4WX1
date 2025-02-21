using C4WX1.API.Features.C4WDeviceToken.Dtos;
using FastEndpoints;

namespace C4WX1.API.Features.C4WDeviceToken.Mappers
{
    public class CreateC4WDeviceTokenMapper 
        : RequestMapper<CreateC4WDeviceTokenDto, Database.Models.C4WDeviceToken>
    {
        public override Database.Models.C4WDeviceToken ToEntity(CreateC4WDeviceTokenDto r) => new()
        {
            OldDeviceToken = r.OldDeviceToken,
            NewDeviceToken = r.NewDeviceToken,
            Device = r.Device,
            ClientEnvironment = r.ClientEnvironment,
            CreatedBy_FK = r.UserId,
            CreatedDate = DateTime.Now
        };
    }
}
