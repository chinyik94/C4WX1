namespace C4WX1.Tests.EnquiryConfig;

public class EnquiryConfigFaker
{
    public static Database.Models.Users DummyUser => new Faker<Database.Models.Users>()
        .RuleFor(x => x.Email, f => f.Internet.Email())
        .RuleFor(x => x.Password, f => f.Internet.Password())
        .RuleFor(x => x.Firstname, f => f.Internet.UserName())
        .RuleFor(x => x.Lastname, f => f.Internet.UserName())
        .RuleFor(x => x.Status, f => f.Lorem.Word())
        .Generate();
}
