namespace C4WX1.API.Features.ProblemList.Dtos;

public sealed class ProblemListDto
{
    public int ProblemListID { get; set; }
    public string ProblemInfo { get; set; } = null!;
    public ICollection<ProblemListGoalDto> ProblemListGoals { get; set; } = [];
    public int DiseaseID_FK { get; set; }
    public bool IsDeleted { get; set; }
    public int? TypeOfGoal { get; set; }
    public string DiseaseName { get; set; } = null!;
    public int? DiseaseSubInfoID_FK { get; set; }
    public bool CanDelete { get; set; }
}
