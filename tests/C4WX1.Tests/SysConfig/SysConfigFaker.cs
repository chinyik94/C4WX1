using C4WX1.Tests.Shared;

namespace C4WX1.Tests.SysConfig
{
    public class SysConfigFaker : C4WX1Faker
    {
        public static Database.Models.SysConfig Dummy() => 
            new Faker<Database.Models.SysConfig>()
                .RuleFor(x => x.ConfigName, f => f.Random.AlphaNumeric(10))
                .RuleFor(x => x.ConfigValue, f => f.Random.AlphaNumeric(10))
                .RuleFor(x => x.IsConfigurable, f => f.Random.Bool())
                .RuleFor(x => x.Description, f => f.Lorem.Sentence())
                .RuleFor(x => x.ModifiedDate, f => DateTime.Now)
                .RuleFor(x => x.ModifiedBy_FK, f => f.Random.Int())
                .Generate();

        public static string ConfigName() => new Faker().Random.AlphaNumeric(10);

        public static string ConfigValue() => new Faker().Random.AlphaNumeric(10);
    }
}
