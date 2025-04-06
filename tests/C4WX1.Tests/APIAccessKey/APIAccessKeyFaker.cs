using C4WX1.API.Features.APIAccessKey.Dtos;

namespace C4WX1.Tests.APIAccessKey
{
    public class APIAccessKeyFaker
    {
        public static GetAPIAccessKeyByCodeDto GetByCodeDto() =>
            new Faker<GetAPIAccessKeyByCodeDto>()
                .RuleFor(x => x.Code, f => f.Random.AlphaNumeric(10))
                .RuleFor(x => x.UserId, f => f.Random.Int())
                .Generate();

        public static GetAPIAccessKeyByAccessKeyDto GetByAccessKeyDto() =>
            new Faker<GetAPIAccessKeyByAccessKeyDto>()
                .RuleFor(x => x.AccessKey, f => f.Random.AlphaNumeric(10))
                .Generate();

        public static int UserId() => new Faker().Random.Int();
    }
}
