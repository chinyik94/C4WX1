using C4WX1.API.Features.C4WDeviceToken.Dtos;
using C4WX1.Tests.Shared;

namespace C4WX1.Tests.C4WDeviceToken
{
    public class C4WDeviceTokenFaker : C4WX1Faker
    {
        public static string OldDeviceToken() => new Faker().Random.AlphaNumeric(10);

        public static CreateC4WDeviceTokenDto CreateDto() => new Faker<CreateC4WDeviceTokenDto>()
            .RuleFor(x => x.OldDeviceToken, f => f.Random.AlphaNumeric(10))
            .RuleFor(x => x.NewDeviceToken, f => f.Random.AlphaNumeric(10))
            .RuleFor(x => x.ClientEnvironment, f => f.Random.AlphaNumeric(10))
            .RuleFor(x => x.Device, f => f.Random.AlphaNumeric(10))
            .RuleFor(x => x.UserId, f => f.Random.Int())
            .Generate();
    }
}
