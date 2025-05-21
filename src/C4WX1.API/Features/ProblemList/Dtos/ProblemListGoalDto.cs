namespace C4WX1.API.Features.ProblemList.Dtos;

public class ProblemListGoalDto
{
    public int ProblemListGoalID { get; set; }
    public int ProblemListID_FK { get; set; }
    public string? Goal { get; set; }
    public int? Action { get; set; }
    public int? ScoreTypeID { get; set; }
    public int? OperatorID { get; set; }
}
