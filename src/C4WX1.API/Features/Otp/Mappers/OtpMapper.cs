using C4WX1.API.Features.Otp.Dtos;

namespace C4WX1.API.Features.Otp.Mappers;

public class OtpMapper
    : ResponseMapper<OtpDto, Database.Models.Otp>
{
    public override OtpDto FromEntity(Database.Models.Otp e)
        => new()
        {
            OtpId = e.OtpId,
            UserId = e.UserId,
            Password = e.Password,
            CreatedDate = e.CreatedDate,
            IsActive = (e.CreatedDate - DateTime.Now).TotalMinutes <= 5
        };
}
