namespace C4WX1.API.Features.TreatmentListItem.Dtos;

public sealed class GetTreatmentListItemCountDto
{
    [QueryParam]
    public string? ProductName { get; set; }

    [QueryParam]
    public int? ProductType { get; set; }
}
