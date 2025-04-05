using FastEndpoints;

namespace C4WX1.API.Features.Language.Dtos
{
    public class GetLanguageByNameDto
    {
        [QueryParam]
        public string Name { get; set; } = null!;
    }
}
