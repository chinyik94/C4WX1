using C4WX1.API.Features.VitalSignType.Dtos;

namespace C4WX1.Tests.VitalSignType;

public class VitalSignTypeFaker
{
    public static CreateVitalSignTypeThresholdDto CreateDto(int? id = null) => new()
    {
        Id = id ?? C4WX1Faker.Id,
        EwsMax1 = 1,
        EwsMax2 = 2,
        EwsMax3 = 3,
        EwsMax4 = 4,
        EwsMax5 = 5,
        EwsMax6 = 6,
        EwsMax7 = 7,
        EwsMin1 = 1,
        EwsMin2 = 2,
        EwsMin3 = 3,
        EwsMin4 = 4,
        EwsMin5 = 5,
        EwsMin6 = 6,
        EwsMin7 = 7,
        UserId = 1,
    };

    public static CreateVitalSignTypeThresholdDto CreateDummy => new Faker<CreateVitalSignTypeThresholdDto>()
        .RuleFor(x => x.EwsMin1, f => f.Random.Decimal())
        .RuleFor(x => x.EwsMin2, f => f.Random.Decimal())
        .RuleFor(x => x.EwsMin3, f => f.Random.Decimal())
        .RuleFor(x => x.EwsMin4, f => f.Random.Decimal())
        .RuleFor(x => x.EwsMin5, f => f.Random.Decimal())
        .RuleFor(x => x.EwsMin6, f => f.Random.Decimal())
        .RuleFor(x => x.EwsMin7, f => f.Random.Decimal())
        .RuleFor(x => x.EwsMax1, f => f.Random.Decimal())
        .RuleFor(x => x.EwsMax2, f => f.Random.Decimal())
        .RuleFor(x => x.EwsMax3, f => f.Random.Decimal())
        .RuleFor(x => x.EwsMax4, f => f.Random.Decimal())
        .RuleFor(x => x.EwsMax5, f => f.Random.Decimal())
        .RuleFor(x => x.EwsMax6, f => f.Random.Decimal())
        .RuleFor(x => x.EwsMax7, f => f.Random.Decimal())
        .RuleFor(x => x.UserId, f => C4WX1Faker.Id)
        .Generate();

    public static UpdateVitalSignTypeThresholdDto UpdateDto(int? id = null) => new()
    {
        Id = id ?? C4WX1Faker.Id,
        EwsMax1 = 1,
        EwsMax2 = 2,
        EwsMax3 = 3,
        EwsMax4 = 4,
        EwsMax5 = 5,
        EwsMax6 = 6,
        EwsMax7 = 7,
        EwsMin1 = 1,
        EwsMin2 = 2,
        EwsMin3 = 3,
        EwsMin4 = 4,
        EwsMin5 = 5,
        EwsMin6 = 6,
        EwsMin7 = 7,
        UserId = 1,
    };
}
