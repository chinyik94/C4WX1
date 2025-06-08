namespace C4WX1.API.Features.WoundReport.Dtos;

public sealed class ExtraDatasetDto
{
    public string Label { get; set; } = null!;
    public List<WoundCountDto> Data { get; set; } = [];
}
