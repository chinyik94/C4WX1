namespace C4WX1.API.Features.Item.Dtos;

public sealed class GetItemCountDto
{
    [QueryParam]
    public string? Keyword { get; set; }

    [QueryParam]
    public int? GroupId { get; set; }

    [QueryParam]
    public bool? AvailableInBilling { get; set; }
}
