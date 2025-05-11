using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.Item.Dtos;

public sealed class GetItemListDto : GetListDto
{
    [QueryParam]
    public string? Keyword { get; set; }

    [QueryParam]
    public int? GroupId { get; set; }

    [QueryParam]
    public bool? AvailableInBilling { get; set; }
}
