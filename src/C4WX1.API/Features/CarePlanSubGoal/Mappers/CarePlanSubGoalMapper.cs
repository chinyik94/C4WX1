using C4WX1.API.Features.CarePlanSubGoal.Dtos;
using FastEndpoints;

namespace C4WX1.API.Features.CarePlanSubGoal.Mappers
{
    public class CarePlanSubGoalMapper
        : ResponseMapper<CarePlanSubGoalDto, Database.Models.CarePlanSubGoal>
    {
        public override CarePlanSubGoalDto FromEntity(Database.Models.CarePlanSubGoal e) => new()
        {
            CarePlanSubGoalID = e.CarePlanSubGoalID,
            CarePlanSubGoalName = e.CarePlanSubGoalName,
            IsDeleted = e.IsDeleted,
            ScoreTypeID = e.ScoreTypeID,
            Score1 = e.Score1,
            Score2 = e.Score2
        };
    }
}
