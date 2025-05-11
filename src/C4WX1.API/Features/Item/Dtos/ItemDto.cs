namespace C4WX1.API.Features.Item.Dtos;

public sealed class ItemDto
{
    public int ItemID { get; set; }
    public string ItemName { get; set; } = null!;
    public int ItemUnitID_FK { get; set; }
    public string ItemUnitName { get; set; } = null!;
    public int CategoryID_FK { get; set; }
    public string CategoryName { get; set; } = null!;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public bool? AvailableInBilling { get; set; }
    public bool CanDelete { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedDate { get; set; }
    public int CreatedBy_FK { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public int? ModifiedBy_FK { get; set; }
}
