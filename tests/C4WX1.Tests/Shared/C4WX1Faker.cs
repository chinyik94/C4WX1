using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.Tests.Shared;

public class C4WX1Faker
{
    public static int CreateCount() => new Faker().Random.Int(10, 20);

    public static GetByIdDto GetByIdDto()
        => new Faker<GetByIdDto>()
            .RuleFor(x => x.Id, f => f.Random.Int(1));

    public static int Id() => new Faker().Random.Int(1);

    public static int UserId() => new Faker().Random.Int(1);
}
