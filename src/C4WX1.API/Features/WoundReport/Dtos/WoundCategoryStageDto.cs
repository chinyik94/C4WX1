namespace C4WX1.API.Features.WoundReport.Dtos;

public sealed class WoundCategoryStageDto
{
    public int PatientWoundID { get; set; }
    public DateTime OccurDate { get; set; }
    public string Category { get; set; } = null!;
    public string Stage { get; set; } = null!;
}
