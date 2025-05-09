using C4WX1.API.Features.CPGoals.Dtos;

namespace C4WX1.Tests.CPGoals;

public class CPGoalsFaker
{
    public static CreateCPGoalsDto CreateDummy => new Faker<CreateCPGoalsDto>()
        .RuleFor(x => x.DiseaseID_FK, f => 1)
        .RuleFor(x => x.CPGoalsInfo, f => C4WX1Faker.AlphaNumeric)
        .RuleFor(x => x.UserId, f => C4WX1Faker.Id)
        .Generate();

    public static CreateCPGoalsDto CreateDto => new()
    {
        DiseaseID_FK = 1,
        CPGoalsInfo = "control-CPGoalsInfo",
        UserId = 1
    };

    public static UpdateCPGoalsDto UpdateDto(int? id = null) => new()
    {
        Id = id ?? C4WX1Faker.Id,
        DiseaseID_FK = CreateDto.DiseaseID_FK,
        CPGoalsInfo = "control-CPGoalsInfo",
        UserId = CreateDto.UserId
    };
}
