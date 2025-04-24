using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.CarePlanSubGoal.Dtos;

public sealed class CreateCarePlanSubGoalDto : CreateDto
{
    public int CarePlanSubID_FK { get; set; }
    public string? CarePlanSubGoalName { get; set; }
}
