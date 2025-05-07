namespace C4WX1.API.Features.Intervention.Dtos;

public sealed class InterventionDto
{
    public int InterventionID { get; set; }
    public int DiseaseID_FK { get; set; }
    public string InterventionInfo { get; set; } = null!;
    public bool IsDeleted { get; set; }
    public InterventionDiseaseDto Disease { get; set; } = null!;
    public bool CanDelete { get; set; }
}
