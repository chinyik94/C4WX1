using C4WX1.API.Features.Activity.Dtos;

namespace C4WX1.Tests.Activity;

public class ActivityFaker
{
    public static CreateActivityDto CreateDummy => new Faker<CreateActivityDto>()
        .RuleFor(x => x.ProblemListID_FK, f => 1)
        .RuleFor(x => x.DiseaseID_FK, f => 1)
        .RuleFor(x => x.UserId, f => C4WX1Faker.Id)
        .RuleFor(x => x.ActivityDetail, f => C4WX1Faker.ShortString)
        .Generate();

    public static CreateActivityDto CreateDto => new()
    {
        ProblemListID_FK = 1,
        DiseaseID_FK = 1,
        ActivityDetail = "control-ActivityDetail",
        UserId = 1
    };

    public static UpdateActivityDto UpdateDto(int? id = null) => new()
    {
        Id = id ?? C4WX1Faker.Id,
        ProblemListID_FK = 1,
        DiseaseID_FK = 1,
        ActivityDetail = "control-ActivityDetail",
        UserId = 1
    };
}
