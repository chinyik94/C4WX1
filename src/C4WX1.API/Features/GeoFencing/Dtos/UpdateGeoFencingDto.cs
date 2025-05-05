using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.GeoFencing.Dtos;

public sealed class UpdateGeoFencingDto : UpdateDto
{
    public string? IP { get; set; }
    public string? Description { get; set; }
}
