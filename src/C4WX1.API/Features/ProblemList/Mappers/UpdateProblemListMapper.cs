using C4WX1.API.Features.ProblemList.Dtos;

namespace C4WX1.API.Features.ProblemList.Mappers;

public class UpdateProblemListMapper
    : RequestMapper<UpdateProblemListDto, Database.Models.ProblemList>
{
    public override Database.Models.ProblemList UpdateEntity(
        UpdateProblemListDto r, 
        Database.Models.ProblemList e)
    {
        e.ProblemInfo = r.ProblemInfo;
        e.DiseaseID_FK = r.DiseaseID_FK;
        e.DiseaseSubInfoID_FK = r.DiseaseSubInfoID_FK;
        e.TypeOfGoal = r.TypeOfGoal;
        e.ModifiedBy_FK = r.UserId;
        e.ModifiedDate = DateTime.Now;

        foreach (var existing in e.ProblemListGoal)
        {
            if (!r.ProblemListGoals.Any(x => x.ScoreTypeID == existing.ScoreTypeID))
            {
                e.ProblemListGoal.Remove(existing);
            }
        }

        foreach (var incoming in r.ProblemListGoals)
        {
            if (!e.ProblemListGoal.Any(x => x.ScoreTypeID == incoming.ScoreTypeID))
            {
                e.ProblemListGoal.Add(new ProblemListGoal
                {
                    Goal = incoming.Goal,
                    Action = incoming.Action,
                    ScoreTypeID = incoming.ScoreTypeID,
                    OperatorID = incoming.OperatorID
                });
            }
        }

        return e;
    }
}
