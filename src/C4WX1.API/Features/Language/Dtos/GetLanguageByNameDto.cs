namespace C4WX1.API.Features.Language.Dtos;

public sealed class GetLanguageByNameDto
{
    [QueryParam]
    public string Name { get; set; } = null!;
}
