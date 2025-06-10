using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.TreatmentListItem.Dtos;

public sealed class UpdateTreatmentListItemDto : UpdateDto
{
    public int TListItemID { get; set; }
    public string ItemName { get; set; } = null!;
    public int TListTypeID_FK { get; set; }
    public bool? IsActive { get; set; }
    public bool? IsSystemUsed { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedDate { get; set; }
    public int CreatedBy_FK { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public int? ModifiedBy_FK { get; set; }
    public string? ItemBrand { get; set; }
    public decimal? Cost { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}
