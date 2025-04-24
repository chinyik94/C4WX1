using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.Activity.Dtos;

public sealed class UpdateActivityDto : UpdateDto
{
    public int ProblemListID_FK { get; set; }
    public int DiseaseID_FK { get; set; }
    public string ActivityDetail { get; set; } = null!;
    public int? DiseaseSubInfoID_FK { get; set; }
}
