using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.Intervention.Dtos;

public sealed class UpdateInterventionDto : UpdateDto
{
    public int DiseaseID_FK { get; set; }
    public string InterventionInfo { get; set; } = null!;
}
