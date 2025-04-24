using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.C4WImage.Dtos;

public sealed class CreateC4WImageDto : CreateDto
{
    public string? WoundImageName { get; set; }
    public string? WoundImageData { get; set; }
    public string? WoundBedImageName { get; set; }
    public string? WoundBedImageData { get; set; }
    public string? TissueImageName { get; set; }
    public string? TissueImageData { get; set; }
    public string? DepthImageName { get; set; }
    public string? DepthImageData { get; set; }
}
