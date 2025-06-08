namespace C4WX1.API.Features.WoundReport.Dtos;

public sealed class WoundAverageFalangaScoreDto
{
    public string Type { get; set; } = null!;
    public string Label { get; set; } = null!;
    public List<WoundCountDto> Data { get; set; } = [];
    public List<ExtraDatasetDto> ExtraData { get; set; } = [];
    public string AverageFirstFalangaScore { get; set; } = null!;
    public string AverageLastFalangaScore { get; set; } = null!;
    public string LastFalangaScoreGreaterThanFirst { get; set; } = null!;
}
