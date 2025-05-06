namespace C4WX1.API.Features.GeoFencing.Dtos;

public sealed class GetGeoFencingIsWhiteListedDto
{
    [QueryParam]
    public string? IP { get; set; }
}
