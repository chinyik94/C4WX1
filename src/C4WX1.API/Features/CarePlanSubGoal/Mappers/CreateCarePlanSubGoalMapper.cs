using C4WX1.API.Features.CarePlanSubGoal.Dtos;
using FastEndpoints;

namespace C4WX1.API.Features.CarePlanSubGoal.Mappers;

public class CreateCarePlanSubGoalMapper
    : RequestMapper<CreateCarePlanSubGoalDto, Database.Models.CarePlanSubGoal>
{
    public override Database.Models.CarePlanSubGoal ToEntity(CreateCarePlanSubGoalDto r) => new()
    {
        CarePlanSubGoalName = r.CarePlanSubGoalName,
        CarePlanSubID_FK = r.CarePlanSubID_FK,
        IsDeleted = false,
        CreatedBy_FK = r.UserId,
        CreatedDate = DateTime.Now
    };
}
