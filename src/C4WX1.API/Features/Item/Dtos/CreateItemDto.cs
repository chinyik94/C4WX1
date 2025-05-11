using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.Item.Dtos;

public sealed class CreateItemDto : CreateDto
{
    public string ItemName { get; set; } = null!;
    public int CategoryID_FK { get; set; }
    public int ItemUnitID_FK { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public bool? AvailableInBilling { get; set; }
}
