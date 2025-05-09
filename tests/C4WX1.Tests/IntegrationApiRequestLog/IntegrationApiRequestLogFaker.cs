using C4WX1.API.Features.IntegrationApiRequestLog.Dtos;

namespace C4WX1.Tests.IntegrationApiRequestLog;

public class IntegrationApiRequestLogFaker
{
    public static CreateIntegrationApiRequestLogDto CreateDummy = new Faker<CreateIntegrationApiRequestLogDto>()
        .RuleFor(x => x.IntegrationSource, f => f.Random.String2(10))
        .RuleFor(x => x.FacilityId, f => C4WX1Faker.Id.ToString())
        .RuleFor(x => x.ResidentId, f => C4WX1Faker.Id.ToString())
        .RuleFor(x => x.Url, f => f.Internet.Url())
        .RuleFor(x => x.Content, f => f.Random.String2(10))
        .RuleFor(x => x.Status, f => f.Random.String2(10))
        .RuleFor(x => x.UserId, f => C4WX1Faker.Id)
        .Generate();

    public static CreateIntegrationApiRequestLogDto CreateControl => new()
    {
        IntegrationSource = "control-IntegrationSource",
        FacilityId = "1",
        ResidentId = "1",
        Url = "control-Url",
        Content = "control-Content",
        Status = "control-Status",
        UserId = 1
    };
}
