namespace C4WX1.API.Features.TreatmentListItem.Dtos;

public sealed class TreatmentListItemDto
{
    public int TListItemID { get; set; }
    public string ItemName { get; set; } = null!;
    public int TListTypeID_FK { get; set; }
    public bool? IsActive { get; set; }
    public bool? IsSystemUsed { get; set; }
    public string? ItemBrand { get; set; }
    public decimal? Cost { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? ProductType { get; set; }
    public bool CanEdit { get; set; }
    public bool CanEditType { get; set; }
    public bool CanDelete { get; set; }
    public bool CanDeactivate { get; set; }
}
