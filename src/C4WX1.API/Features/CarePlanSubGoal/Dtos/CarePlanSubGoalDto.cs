namespace C4WX1.API.Features.CarePlanSubGoal.Dtos;

public sealed class CarePlanSubGoalDto
{
    public int CarePlanSubGoalID { get; set; }
    public int? ScoreTypeID { get; set; }
    public decimal? Score1 { get; set; }
    public decimal? Score2 { get; set; }
    public string? CarePlanSubGoalName { get; set; }
    public bool? IsDeleted { get; set; }
    public bool CanDelete { get; set; }
}
