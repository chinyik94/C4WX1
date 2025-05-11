using C4WX1.API.Features.Item.Dtos;

namespace C4WX1.Tests.Item;

public class ItemFaker
{
    public static CreateItemDto CreateDto => new()
    {
        ItemName = "control-ItemName",
        ItemUnitID_FK = 1,
        CategoryID_FK = 2,
        Quantity = 1,
        UnitPrice = 1M,
        AvailableInBilling = true,
        UserId = C4WX1Faker.Id
    };

    public static CreateItemDto CreateDummy => new Faker<CreateItemDto>()
        .RuleFor(x => x.ItemName, f => C4WX1Faker.ShortString)
        .RuleFor(x => x.ItemUnitID_FK, f => 1)
        .RuleFor(x => x.CategoryID_FK, f => 2)
        .RuleFor(x => x.Quantity, f => f.Random.Int(0))
        .RuleFor(x => x.UnitPrice, f => f.Random.Decimal())
        .RuleFor(x => x.AvailableInBilling, f => f.Random.Bool())
        .RuleFor(x => x.UserId, f => C4WX1Faker.Id)
        .Generate();

    public static UpdateItemDto UpdateDto(int? id = null) => new()
    {
        Id = id ?? C4WX1Faker.Id,
        ItemName = "updated-control-ItemName",
        ItemUnitID_FK = 1,
        CategoryID_FK = 2,
        Quantity = 1,
        UnitPrice = 1M,
        AvailableInBilling = true,
        UserId = C4WX1Faker.Id
    };
}
