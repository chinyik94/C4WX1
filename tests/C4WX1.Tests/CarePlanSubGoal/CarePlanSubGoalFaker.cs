using C4WX1.API.Features.CarePlanSubGoal.Dtos;

namespace C4WX1.Tests.CarePlanSubGoal;
public class CarePlanSubGoalFaker
{
    public static CreateCarePlanSubGoalDto CreateDto => new()
    {
        CarePlanSubGoalName = "control-CarePlanSubGoalName",
        CarePlanSubID_FK = 1,
        UserId = 1
    };

    public static CreateCarePlanSubGoalDto CreateDummy => new()
    {
        CarePlanSubGoalName = C4WX1Faker.ShortString,
        CarePlanSubID_FK = 1,
        UserId = 1
    };

    public static UpdateCarePlanSubGoalDto UpdateDto(int? id = null) => new()
    {
        Id = id ?? C4WX1Faker.Id,
        CarePlanSubGoalName = C4WX1Faker.ShortString,
        CarePlanSubID_FK = CreateDto.CarePlanSubID_FK,
        UserId = CreateDto.UserId
    };
}
