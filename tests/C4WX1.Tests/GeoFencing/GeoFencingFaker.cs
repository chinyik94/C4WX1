using C4WX1.API.Features.GeoFencing.Dtos;

namespace C4WX1.Tests.GeoFencing;

public class GeoFencingFaker
{
    public static CreateGeoFencingDto CreateDummy => new Faker<CreateGeoFencingDto>()
        .RuleFor(x => x.IP, f => f.Random.AlphaNumeric(10))
        .RuleFor(x => x.Description, f => f.Random.String2(10))
        .RuleFor(x => x.UserId, f => C4WX1Faker.Id)
        .Generate();

    public static CreateGeoFencingDto CreateDto => new()
    {
        IP = "control-IP",
        Description = "control-Description",
        UserId = 1
    };

    public static UpdateGeoFencingDto UpdateDto(int? id = null) => new()
    {
        Id = id ?? C4WX1Faker.Id,
        IP = "updated-IP",
        Description = "updated-Description",
        UserId = 1
    };
}
