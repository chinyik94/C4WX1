namespace C4WX1.API.Features.Activity.Dtos;

public sealed class UpdateActivityDto
{
    public int ActivityID { get; set; }
    public int ProblemListID_FK { get; set; }
    public int DiseaseID_FK { get; set; }
    public string ActivityDetail { get; set; } = null!;
    public int? DiseaseSubInfoID_FK { get; set; }
    public int UserId { get; set; }
}
