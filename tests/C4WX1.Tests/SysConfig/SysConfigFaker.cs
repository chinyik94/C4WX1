using C4WX1.API.Features.SysConfig.Dtos;
using C4WX1.Tests.Shared;

namespace C4WX1.Tests.SysConfig
{
    public class SysConfigFaker : C4WX1Faker
    {
        public static CreateSysConfigDto CreateDto() => 
            new Faker<CreateSysConfigDto>()
                .RuleFor(x => x.ConfigName, f => f.Random.AlphaNumeric(10))
                .RuleFor(x => x.ConfigValue, f => f.Random.AlphaNumeric(10))
                .RuleFor(x => x.IsConfigurable, f => f.Random.Bool())
                .RuleFor(x => x.Description, f => f.Lorem.Sentence())
                .Generate();

        public static UpdateSysConfigDto UpdateDto() =>
            new Faker<UpdateSysConfigDto>()
                .RuleFor(x => x.ConfigName, f => f.Random.AlphaNumeric(10))
                .RuleFor(x => x.ConfigValue, f => f.Random.AlphaNumeric(10))
                .RuleFor(x => x.UserID, f => f.Random.Int())
                .Generate();

        public static string ConfigName() => new Faker().Random.AlphaNumeric(10);

        public static string ConfigValue() => new Faker().Random.AlphaNumeric(10);

        public static int UserId() => new Faker().Random.Int();
    }
}
