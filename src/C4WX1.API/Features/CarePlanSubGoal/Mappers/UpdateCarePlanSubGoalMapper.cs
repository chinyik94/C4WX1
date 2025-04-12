using C4WX1.API.Features.CarePlanSubGoal.Dtos;
using FastEndpoints;

namespace C4WX1.API.Features.CarePlanSubGoal.Mappers;

public class UpdateCarePlanSubGoalMapper
    : RequestMapper<UpdateCarePlanSubGoalDto, Database.Models.CarePlanSubGoal>
{
    public override Database.Models.CarePlanSubGoal UpdateEntity(
        UpdateCarePlanSubGoalDto r, 
        Database.Models.CarePlanSubGoal e)
    {
        e.CarePlanSubGoalName = r.CarePlanSubGoalName;
        e.CarePlanSubID_FK = r.CarePlanSubID_FK;
        e.ModifiedBy_FK = r.UserId;
        e.ModifiedDate = DateTime.Now;

        return e;
    }
}
