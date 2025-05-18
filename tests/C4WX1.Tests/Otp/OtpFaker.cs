using C4WX1.API.Features.Otp.Dtos;

namespace C4WX1.Tests.Otp;

public class OtpFaker
{
    public static CreateOtpDto CreateDto => new()
    {
        UserId = 1
    };

    public static CreateOtpDto CreateDummy => new Faker<CreateOtpDto>()
        .RuleFor(x => x.UserId, f => C4WX1Faker.Id)
        .Generate();
}
