namespace C4WX1.API.Features.CPGoals.Dtos;

public sealed class CPGoalsDto
{
    public int CPGoalsID { get; set; }
    public int DiseaseID_FK { get; set; }
    public string CPGoalsInfo { get; set; } = null!;
    public string CPGoalsName { get; set; } = null!;
    public bool CanDelete { get; set; }
    public bool IsDeleted { get; set; }
    public CPGoalsDiseaseDto Disease { get; set; } = null!;
}
