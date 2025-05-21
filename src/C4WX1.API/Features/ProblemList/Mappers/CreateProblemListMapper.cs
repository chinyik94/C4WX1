using C4WX1.API.Features.ProblemList.Dtos;

namespace C4WX1.API.Features.ProblemList.Mappers;

public class CreateProblemListMapper
    : RequestMapper<CreateProblemListDto, Database.Models.ProblemList>
{
    public override Database.Models.ProblemList ToEntity(CreateProblemListDto r)
        => new()
        {
            ProblemInfo = r.ProblemInfo,
            DiseaseID_FK = r.DiseaseID_FK,
            DiseaseSubInfoID_FK = r.DiseaseSubInfoID_FK,
            TypeOfGoal = r.TypeOfGoal,
            CreatedBy_FK = r.UserId,
            CreatedDate = DateTime.Now,
            ProblemListGoal = [.. r.ProblemListGoals.Select(x => new ProblemListGoal
            {
                Goal = x.Goal,
                Action = x.Action,
                ScoreTypeID = x.ScoreTypeID,
                OperatorID = x.OperatorID
            })]
        };
}
