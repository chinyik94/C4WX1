using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.Tests.Shared;

public class C4WX1Faker
{
    public static int CreateCount => new Faker().Random.Int(10, 20);

    public static GetByIdDto GetByIdDto => new Faker<GetByIdDto>()
            .RuleFor(x => x.Id, f => f.Random.Int(1));

    public static int Id => new Faker().Random.Int(1);

    public static int UserId => new Faker().Random.Int(1);

    public static string ShortString => new Faker().Random.String2(10);

    public static Database.Models.Users DummyUser => new Faker<Database.Models.Users>()
        .RuleFor(x => x.Email, f => f.Internet.Email())
        .RuleFor(x => x.Password, f => f.Internet.Password())
        .RuleFor(x => x.Firstname, f => f.Internet.UserName())
        .RuleFor(x => x.Lastname, f => f.Internet.UserName())
        .RuleFor(x => x.Status, f => f.Lorem.Word())
        .Generate();
}
