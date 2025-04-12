namespace C4WX1.API.Features.CarePlanSubGoal.Dtos;

public sealed class UpdateCarePlanSubGoalDto
{
    public int CarePlanSubGoalID { get; set; }
    public int CarePlanSubID_FK { get; set; }
    public string? CarePlanSubGoalName { get; set; }
    public int UserId { get; set; }
}
