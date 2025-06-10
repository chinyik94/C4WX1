using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.TreatmentListItem.Dtos;

public sealed class GetTreatmentListItemIsExistsDto : GetByIdDto
{
    [QueryParam]
    public int? ProductTypeId { get; set; }

    [QueryParam]
    public string? ProductName { get; set; }

    [QueryParam]
    public string? ProductBrand { get; set; }
}
