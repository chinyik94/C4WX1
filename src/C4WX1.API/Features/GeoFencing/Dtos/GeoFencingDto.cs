namespace C4WX1.API.Features.GeoFencing.Dtos;

public sealed class GeoFencingDto
{
    public int GeoFencingId { get; set; }
    public string? IP { get; set; }
    public string? Description { get; set; }
    public bool? IsWhitelisted { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedDate { get; set; }
    public int? CreatedBy_FK { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public int? ModifiedBy_FK { get; set; }
}
