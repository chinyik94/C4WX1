using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.ProblemList.Dtos;

public sealed class CreateProblemListDto : CreateDto
{
    public int DiseaseID_FK { get; set; }
    public string ProblemInfo { get; set; } = null!;
    public int? TypeOfGoal { get; set; }
    public int? DiseaseSubInfoID_FK { get; set; }
    public ICollection<ProblemListGoalDto> ProblemListGoals { get; set; } = [];
}
