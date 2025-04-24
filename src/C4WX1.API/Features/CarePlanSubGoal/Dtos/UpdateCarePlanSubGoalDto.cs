using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.CarePlanSubGoal.Dtos;

public sealed class UpdateCarePlanSubGoalDto : UpdateDto
{
    public int CarePlanSubID_FK { get; set; }
    public string? CarePlanSubGoalName { get; set; }
}
