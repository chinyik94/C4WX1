namespace C4WX1.API.Features.WoundReport.Dtos;

public sealed class InfectedVisitReportDto
{
    public string Type { get; set; } = null!;
    public string Label { get; set; } = null!;
    public List<WoundCountDto> Data { get; set; } = [];
    public List<ExtraDatasetDto> ExtraData { get; set; } = [];
    public string TotalCount { get; set; } = null!;
    public string AverageCount { get; set; } = null!;
    public string NonInfectedCount { get; set; } = null!;
    public string SlowHealingCount { get; set; } = null!;
}
