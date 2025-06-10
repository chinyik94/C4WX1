using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.TreatmentListItem.Dtos;

public sealed class GetTreatmentListItemListDto : GetListDto
{
    [QueryParam]
    public string? ProductName { get; set; }

    [QueryParam]
    public int? ProductType { get; set; }
}
