using C4WX1.API.Features.ProblemList.Dtos;

namespace C4WX1.Tests.ProblemList;

public class ProblemListFaker
{
    public static CreateProblemListDto CreateDto => new()
    {
        DiseaseID_FK = 1,
        ProblemInfo = "control-ProblemInfo",
        TypeOfGoal = 1,
        DiseaseSubInfoID_FK = 1,
        UserId = 1,
        ProblemListGoals = [
            new ProblemListGoalDto{
                Action = 1,
                Goal = "control-Goal",
                ScoreTypeID = 1,
                OperatorID = 1
            }
            ]
    };

    public static CreateProblemListDto CreateDummy => new Faker<CreateProblemListDto>()
        .RuleFor(x => x.DiseaseID_FK, f => 1)
        .RuleFor(x => x.ProblemInfo, f => C4WX1Faker.ShortString)
        .RuleFor(x => x.TypeOfGoal, f => C4WX1Faker.Id)
        .RuleFor(x => x.DiseaseSubInfoID_FK, f => 1)
        .Generate();

    private static ProblemListGoalDto DummyProblemListGoalDto => new Faker<ProblemListGoalDto>()
        .RuleFor(x => x.Action, f => C4WX1Faker.Id)
        .RuleFor(x => x.Goal, f => C4WX1Faker.ShortString)
        .RuleFor(x => x.OperatorID, f => 1)
        .RuleFor(x => x.ScoreTypeID, f => 1)
        .Generate();

    public static UpdateProblemListDto UpdateDto(int? id = null) => new()
    {
        Id = id ?? C4WX1Faker.Id,
        DiseaseID_FK = 1,
        ProblemInfo = "updated-control-ProblemInfo",
        TypeOfGoal = 1,
        DiseaseSubInfoID_FK = 1,
        UserId = 1,
        ProblemListGoals = [
            new ProblemListGoalDto{
                Action = 1,
                Goal = "updated-control-Goal",
                ScoreTypeID = 1,
                OperatorID = 1
            }
            ]
    };
}
