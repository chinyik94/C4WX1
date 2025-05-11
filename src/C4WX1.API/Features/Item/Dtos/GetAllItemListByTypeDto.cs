namespace C4WX1.API.Features.Item.Dtos;

public sealed class GetAllItemListByTypeDto
{
    public int TypeId { get; set; }

    [QueryParam]
    public bool? AvailableInBilling { get; set; }
}
