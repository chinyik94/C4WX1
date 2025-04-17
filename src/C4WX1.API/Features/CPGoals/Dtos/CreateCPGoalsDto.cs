using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.CPGoals.Dtos;

public sealed class CreateCPGoalsDto : CreateDto
{
    public int DiseaseID_FK { get; set; }
    public string CPGoalsInfo { get; set; } = null!;
}
