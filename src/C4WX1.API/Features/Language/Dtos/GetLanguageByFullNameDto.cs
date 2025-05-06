namespace C4WX1.API.Features.Language.Dtos;

public sealed class GetLanguageByFullNameDto
{
    [QueryParam]
    public string FullName { get; set; } = null!;
}
