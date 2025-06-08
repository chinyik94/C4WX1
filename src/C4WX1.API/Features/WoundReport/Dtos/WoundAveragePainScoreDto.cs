namespace C4WX1.API.Features.WoundReport.Dtos;

public sealed class WoundAveragePainScoreDto
{
    public string Type { get; set; } = null!;
    public string Label { get; set; } = null!;
    public List<WoundCountDto> Data { get; set; } = [];
    public List<ExtraDatasetDto> ExtraData { get; set; } = [];
}
