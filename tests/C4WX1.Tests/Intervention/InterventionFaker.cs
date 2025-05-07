using C4WX1.API.Features.Intervention.Dtos;
using C4WX1.Tests.Shared;

namespace C4WX1.Tests.Intervention;

public class InterventionFaker
{
    public static CreateInterventionDto CreateDummy => new Faker<CreateInterventionDto>()
        .RuleFor(x => x.DiseaseID_FK, f => 1)
        .RuleFor(x => x.InterventionInfo, f => C4WX1Faker.ShortString)
        .RuleFor(x => x.UserId, f => C4WX1Faker.Id)
        .Generate();

    public static UpdateInterventionDto UpdateDummy(int? id = null) => new Faker<UpdateInterventionDto>()
        .RuleFor(x => x.Id, f => id ?? C4WX1Faker.Id)
        .RuleFor(x => x.DiseaseID_FK, f => 1)
        .RuleFor(x => x.InterventionInfo, f => C4WX1Faker.ShortString)
        .RuleFor(x => x.UserId, f => C4WX1Faker.Id)
        .Generate();

    public static CreateInterventionDto CreateControl => new()
    {
        DiseaseID_FK = 1,
        InterventionInfo = "control-InterventionInfo",
        UserId = 1
    };
}
