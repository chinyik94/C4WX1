using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.TreatmentListItem.Dtos;

public sealed class UpdateTreatmentListItemDto : UpdateDto
{
    public string ItemName { get; set; } = null!;
    public int TListTypeID_FK { get; set; }
    public string? ItemBrand { get; set; }
    public decimal? Cost { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}
