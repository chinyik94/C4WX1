using C4WX1.API.Features.GeoFencing.Dtos;
using C4WX1.Tests.Shared;

namespace C4WX1.Tests.GeoFencing;

public class GeoFencingFaker
{
    public static CreateGeoFencingDto CreateDummy => new Faker<CreateGeoFencingDto>()
        .RuleFor(x => x.IP, f => f.Random.AlphaNumeric(10))
        .RuleFor(x => x.Description, f => f.Random.String2(10))
        .RuleFor(x => x.UserId, f => C4WX1Faker.Id)
        .Generate();
}
