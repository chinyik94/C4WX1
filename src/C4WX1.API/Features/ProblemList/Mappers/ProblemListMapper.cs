using C4WX1.API.Features.ProblemList.Dtos;

namespace C4WX1.API.Features.ProblemList.Mappers;

public class ProblemListMapper
    : ResponseMapper<ProblemListDto, Database.Models.ProblemList>
{
    public override ProblemListDto FromEntity(Database.Models.ProblemList e)
        => new()
        {
            ProblemListID = e.ProblemListID,
            ProblemInfo = e.ProblemInfo,
            ProblemListGoals = [.. e.ProblemListGoal.Select(x => new ProblemListGoalDto
            {
                ProblemListGoalID = x.ProblemListGoalID,
                ProblemListID_FK = x.ProblemListID_FK,
                ScoreTypeID = x.ScoreTypeID,
                Action = x.Action,
                Goal = x.Goal,
                OperatorID = x.OperatorID
            })],
            IsDeleted = e.IsDeleted,
            TypeOfGoal = e.TypeOfGoal,
            DiseaseName = e.DiseaseID_FKNavigation.DiseaseName,
            DiseaseSubInfoID_FK = e.DiseaseSubInfoID_FK,
            DiseaseID_FK = e.DiseaseID_FK
        };
}
